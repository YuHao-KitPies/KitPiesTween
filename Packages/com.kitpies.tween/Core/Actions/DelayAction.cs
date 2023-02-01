using System;
namespace KP.Tween
{
    internal class DelayAction : IntervalAction
    {
        public DelayAction(float duration) : base(duration)
        {
        }

        public override void Update(float ratio) { }

        public override Action Clone()
        {
            var action = new DelayAction(this.duration);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
