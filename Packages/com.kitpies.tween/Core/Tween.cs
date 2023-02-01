using System;
using System.Collections.Generic;
using System.Linq;

namespace KP.Tween
{
    public class Tween
    {
        protected struct DualMasterSlaveSwich
        {
            private static readonly int[] OffTrans = new int[] { 0b1000, 0b1101, 0b1110, 0b1100 };
            private static readonly int[] OnTrans = new int[] { 0b0010, 0b0111, 0b1011, 0b0011 };
            private const int SlaveMask = 1 << 0;
            private const int MainMask = 1 << 1;
            private bool isOn;
            private int state;

            public bool IsOn { get => this.isOn; }

            public void TurnOnMain()
            {
                this.HandleState(state, this.state | MainMask | SlaveMask);
            }

            public void TurnOffMain()
            {
                this.HandleState(state, this.state & ~MainMask & ~SlaveMask);
            }

            public void TurnOnSlave()
            {
                this.HandleState(state, this.state | SlaveMask);
            }

            public void TurnOffSlave()
            {
                this.HandleState(state, this.state & ~SlaveMask);
            }

            private void HandleState(int oldState, int newState)
            {
                this.state = newState;
                var trans = oldState << 2 | newState;
                if (OnTrans.Contains(trans))
                {
                    this.isOn = true;
                }
                else if (OffTrans.Contains(trans))
                {
                    this.isOn = false;
                }
            }
        }

        internal List<Action> actions = new List<Action>();
        internal virtual object Target { get => null; }
        private Action finalAction;
        protected TweenManager tm;
        protected bool isStart;
        protected DualMasterSlaveSwich isPlaying = new DualMasterSlaveSwich();

        internal Tween() { }

        internal Action UnionInternal()
        {
            Action action;
            if (actions.Count == 1)
            {
                action = actions[0];
            }
            else
            {
                action = new SequenceAction(this.actions);
            }
            return action;
        }

        internal Action UnionInternalWithTarget()
        {
            var action = UnionInternal();
            action.BindTarget = this.Target;
            return action;
        }

        internal bool IsDone()
        {
            return this.finalAction.IsDone;
        }

        internal void Step(float dt)
        {
            if (this.isPlaying.IsOn)
            {
                this.finalAction.Step(dt);
            }
        }

        internal void Finish()
        {
            this.tm.RemoveATween(this);
            this.finalAction = null;
            this.isStart = false;
            this.isPlaying.TurnOffMain();
        }

        internal void PauseInGloble()
        {
            if (this.isStart && this.isPlaying.IsOn)
            {
                this.isPlaying.TurnOffSlave();
            }
        }

        internal void ResumeInGloble()
        {
            if (this.isStart && !this.isPlaying.IsOn)
            {
                this.isPlaying.TurnOnSlave();
            }
        }

        public void Start()
        {
            if (this.isStart)
            {
                this.Stop();
            }

            this.finalAction = this.UnionInternal();
            this.finalAction.Start(Target);
            this.tm.AddATween(this);
            this.isStart = true;
            this.isPlaying.TurnOnMain();
        }

        public void Stop()
        {
            if (this.isStart)
            {
                this.Finish();
            }
        }

        public void Pause()
        {
            if (this.isStart && this.isPlaying.IsOn)
            {
                this.isPlaying.TurnOffMain();
            }
        }

        public void Resume()
        {
            if (this.isStart && !this.isPlaying.IsOn)
            {
                this.isPlaying.TurnOnMain();
            }
        }

        public Tween Then(Tween tween)
        {
            var action = tween.UnionInternalWithTarget();
            this.actions.Add(action);
            return this;
        }

        public Tween Sequence(params Tween[] tweens)
        {
            Action[] actions = tweens.Select(el =>el.UnionInternalWithTarget()).ToArray();
            var action = new SequenceAction(actions);
            this.actions.Add(action);
            return this;
        }

        public Tween Parallel(params Tween[] tweens)
        {
            List<Action> actions = tweens.Select(el => el.UnionInternalWithTarget()).ToList();
            this.actions.Add(new ParallelAction(actions));
            return this;
        }

        public Tween Delay(float duration)
        {
            this.actions.Add(new DelayAction(duration));
            return this;
        }

        public Tween Repeat(int times)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatAction(action, times));
            return this;
        }

        public Tween RepeatForEver()
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatForEverAction(action));
            return this;
        }

        public Tween Speed(float speed)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new SpeedAction(action, speed));
            return this;
        }

        public virtual Tween Clone()
        {
            throw new NotImplementedException();
        }
    }

    public class Tween<T>: Tween
    {
        protected T target;
        internal override object Target { get => this.target; }

        internal Tween(T target, TweenManager tm)
        {
            this.target = target;
            this.tm = tm;
        }

        public new Tween<T> Then(Tween tween)
        {
            var action = tween.UnionInternalWithTarget();
            this.actions.Add(action);
            return this;
        }

        public new Tween<T> Sequence(params Tween[] tweens)
        {
            Action[] actions = tweens.Select(el => el.UnionInternalWithTarget()).ToArray();
            var action = new SequenceAction(actions);
            this.actions.Add(action);
            return this;
        }

        public new Tween<T> Parallel(params Tween[] tweens)
        {
            List<Action> actions = tweens.Select(el => el.UnionInternalWithTarget()).ToList();
            this.actions.Add(new ParallelAction(actions));
            return this;
        }

        public new Tween<T> Delay(float duration)
        {
            this.actions.Add(new DelayAction(duration));
            return this;
        }

        public new Tween<T> Repeat(int times)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatAction(action, times));
            return this;
        }

        public new Tween<T> RepeatForEver()
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatForEverAction(action));
            return this;
        }

        public new Tween<T> Speed(float speed)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new SpeedAction(action, speed));
            return this;
        }

        public Tween<T> To<D>(float duration, IProp<T, D> prop) where D : struct
        {
            var action = new ToAction<T, D>(duration, prop);
            this.actions.Add(action);
            return this;
        }

        public Tween<T> By<D>(float duration, IProp<T, D> prop) where D : struct
        {
            var action = new ByAction<T, D>(duration, prop);
            this.actions.Add(action);
            return this;
        }

        public Tween<T> Set<D>(IProp<T, D> prop) where D : struct
        {
            var action = new SetAction<T, D>(prop);
            this.actions.Add(action);
            return this;
        }

        public Tween<T> Call(CallFunc<T> callFunc)
        {
            var action = new CallAction<T>(callFunc);
            this.actions.Add(action);
            return this;
        }

        public override Tween Clone()
        {
            var tween = new Tween<T>(this.target, this.tm);
            tween.actions = this.actions.Select(el=>el.Clone()).ToList();
            return tween;
        }
    }
}
