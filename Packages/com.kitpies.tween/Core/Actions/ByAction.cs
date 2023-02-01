using System;
namespace KP.Tween
{
    internal class ByAction<T, D> : IntervalAction where D: struct
    {
        private IProp<T, D> prop;

        public ByAction(float duration, IProp<T, D> prop) : base(duration)
        {
            this.prop = prop;
        }

        public override void Start(object target)
        {
            base.Start(target);
            this.prop.Fill((T)Target);
        }

        public override void Update(float ratio)
        {
            var nr = this.prop.EasingValue(ratio);

            var current = this.prop.Progress(nr, true);

            this.prop.Update((T)Target, nr, current);
        }

        public override Action Clone()
        {
            var action = new ByAction<T, D>(this.duration, this.prop);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
