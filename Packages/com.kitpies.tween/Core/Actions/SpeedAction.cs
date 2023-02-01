using System;
namespace KP.Tween
{
    internal class SpeedAction : IntervalAction
    {
        private float speed;
        private Action action;

        public SpeedAction(Action action, float speed) : base(action.Duration)
        {
            if (action != null)
            {
                this.action = action;
            }
            else
            {
                throw new ArgumentNullException(nameof(action));
            }
            this.speed = speed < 0? 1: speed;
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
            else
            {
                this.elapsed += dt * this.speed;
            }

            this.action.Step(dt * this.speed);
        }

        public override Action Clone()
        {
            var action = new SpeedAction(this.action.Clone(), this.speed);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
