using System;
using System.Collections.Generic;
using System.Linq;

namespace KP.Tween
{
    internal class RepeatAction : IntervalAction
    {
        private int repeatNum;
        private int repeatTimes;
        private Action action;

        public override bool IsDone => base.IsDone && this.repeatNum >= this.repeatTimes;

        public RepeatAction(Action action, int repeatTimes): base(0)
        {
            if (action != null)
            {
                this.action = action;
            }
            else
            {
                throw new ArgumentNullException(nameof(action));
            }
            this.repeatTimes = repeatTimes;
            this.duration = this.CalDuration(action, repeatTimes);
        }

        private float CalDuration(Action action, int repeatTimes)
        {
            return action.Duration * repeatTimes;
        }

        public override void Start(object target)
        {
            base.Start(target);
            this.repeatNum = 0;
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
                this.repeatNum ++;
                this.elapsed += this.action.Duration;
                this.action.Reset();
                this.action.Start(Target);
                this.action.Step(dt);
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.repeatNum = 0;
        }

        public override Action Clone()
        {
            var action = new RepeatAction(this.action.Clone(), this.repeatTimes);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
