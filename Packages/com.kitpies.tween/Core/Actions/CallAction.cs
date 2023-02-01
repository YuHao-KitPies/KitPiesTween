using System;
namespace KP.Tween
{
    internal class CallAction<T>: InstantAction
    {
        private CallFunc<T> callFunc;

        public CallAction(CallFunc<T> callFunc)
        {
            this.callFunc = callFunc;
        }

        public override void Update(float ratio)
        {
            if (this.callFunc != null)
            {
                this.callFunc((T)this.Target);
            }
        }

        public override Action Clone()
        {
            var action = new CallAction<T>(this.callFunc);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
