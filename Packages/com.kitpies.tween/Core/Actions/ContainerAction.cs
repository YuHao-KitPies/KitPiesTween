using System;
using System.Collections.Generic;
using System.Linq;

namespace KP.Tween
{
    internal class ContainerAction: IntervalAction
    {
        protected List<Action> actions = new List<Action>();

        public List<Action> Actions { get => this.actions; }

        public override bool IsDone { get => base.IsDone && this.actions.All(el => el.IsDone); }

        public ContainerAction(float duration, List<Action> actions) : base(duration)
        {
            if (actions != null)
            {
                this.actions = actions.Where( el=> el != null).ToList();
            }
            else
            {
                throw new ArgumentNullException(nameof(actions));
            }
        }
    }
}
