using System;
namespace KP.Tween
{
    internal class RepeatForEverAction : IntervalAction
    {
        private Action action;

        public RepeatForEverAction(Action action) : base(float.MaxValue)
        {
            if (action != null)
            {
                this.action = action;
            }
            else
            {
                throw new ArgumentNullException(nameof(action));
            }
        }

        public override void Start(object target)
        {
            base.Start(target);
            this.action.Start(Target);
        }

        public override void Stop()
        {
            this.action.Stop();
            base.Stop();
        }

        public override void Step(float dt)
        {
            if (this.firstTick)
            {
                this.firstTick = false;
                this.elapsed = 0;
            }

            if (!this.action.IsDone)
            {
                this.action.Step(dt);
            }
            else
            {
                this.elapsed += this.action.Duration;
                this.action.Reset();
                this.action.Start(Target);
                this.action.Step(dt);
            }
        }

        public override Action Clone()
        {
            var action = new RepeatForEverAction(this.action.Clone());
            this.CheckBindTarget(action);
            return action;
        }
    }
}
