using System;
namespace KP.Tween
{
    internal class InstantAction: Action
    {
        protected bool isDone;

        public override bool IsDone { get => this.isDone; }

        public override void Start(object target)
        {
            base.Start(target);
            this.isDone = false;
        }

        public override void Step(float dt)
        {
            if (this.ShouldStep())
            {
                this.Update(1);
            }
            this.isDone = true;
        }

        public override void Reset()
        {
            this.isDone = false;
        }
    }
}
