using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace KP.Tween
{
    internal class ParallelAction : ContainerAction
    {
        public ParallelAction(List<Action> actions) : base(0, actions)
        {
            this.duration = this.CalDuration(this.actions);
        }

        private float CalDuration(List<Action> actions)
        {
            return actions.Max(el => el.Duration);
        }

        public override void Start(object target)
        {
            base.Start(target);
            for (var i = 0; i < this.actions.Count; i++)
            {   
                this.actions[i].Start(Target);
            }
        }

        public override void Stop()
        {
            for (var i = 0; i < this.actions.Count; i++)
            {
                this.actions[i].Stop();
            }
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
                this.elapsed += dt;
            }

            for (var i = 0; i < this.actions.Count; i++)
            {
                if (!this.actions[i].IsDone)
                {
                    this.actions[i].Step(dt);
                }
            }
        }

        public override Action Clone()
        {
            var action = new ParallelAction(this.actions.Select(el => el.Clone()).ToList());
            this.CheckBindTarget(action);
            return action;
        }
    }
}
