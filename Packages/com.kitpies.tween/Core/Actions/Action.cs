using System;
using UnityEngine.UIElements;

namespace KP.Tween
{
    internal class Action
    {
        private VisualElement cacheTarget;
        private object target;
        private object bindTarget;

        public object Target {
            get => this.target;
            internal set
            {
                this.target = value;
                if (value is VisualElement)
                {
                    this.cacheTarget = value as VisualElement;
                }
            }
        }

        public object BindTarget
        {
            get => this.bindTarget;
            internal set
            {
                this.bindTarget = value;
                this.Target = value;
            }
        }

        public virtual bool IsDone { get => false; }

        public virtual float Elapsed { get => 0; }
        public virtual float Duration { get => 0; }

        public Action() { }

        protected bool ShouldStep()
        {
            if (this.cacheTarget != null)
            {
                return this.cacheTarget.enabledInHierarchy;
            }
            else
            {
                return true;
            }
        }

        protected void CheckBindTarget(Action action)
        {
            if (this.BindTarget != null)
            {
                action.BindTarget = BindTarget;
            }
        }

        public virtual void Start(object target)
        {
            if (this.bindTarget == null)
            {
                this.Target = target;
            }
        }

        public virtual void Stop()
        {
            if (this.bindTarget == null)
            {
                this.target = null;
                this.cacheTarget = null;
            }
        }

        public virtual void Step(float dt) { }

        public virtual void Update(float ratio) { }

        public virtual void Reset() { }

        public virtual Action Clone()
        {
            return new Action();
        }
    }
}
