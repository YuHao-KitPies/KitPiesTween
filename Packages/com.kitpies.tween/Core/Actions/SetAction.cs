using System;
namespace KP.Tween
{
    internal class SetAction<T, D>: InstantAction where D: struct
    {
        private IProp<T, D> prop;

        public SetAction(IProp<T, D> prop)
        {
            this.prop = prop;
        }

        public override void Update(float ratio)
        {
            this.prop.Update((T)this.Target, 1, this.prop.End(false));
        }

        public override Action Clone()
        {
            var action = new SetAction<T, D>(this.prop);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
