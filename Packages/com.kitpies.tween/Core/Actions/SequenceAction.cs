using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace KP.Tween
{
    internal class SequenceAction: ContainerAction
    {
        private IEnumerator<Action> enumerator;

        public SequenceAction(List<Action> actions) : base(0, actions)
        {
            enumerator = this.actions.GetEnumerator();
            this.duration = this.CalDuration(this.actions);
        }

        public SequenceAction(params Action[] actions) : base(0, actions.ToList())
        {
            enumerator = this.actions.GetEnumerator();
            this.duration = this.CalDuration(this.actions);
        }
        
        private float CalDuration(List<Action> actions)
        {
            return actions.Sum(el => el.Duration);
        }

        public override void Start(object target)
        {
            base.Start(target);
            enumerator.Reset();
            enumerator.MoveNext();
            if (enumerator.Current != null)
            {   
                enumerator.Current.Start(Target);
            }
        }

        public override void Step(float dt)
        {
            if (this.firstTick)
            {
                this.firstTick = false;
                this.elapsed = 0;
            }

            if (enumerator.Current != null)
            {
                if (enumerator.Current.IsDone)
                {
                    this.elapsed += enumerator.Current.Duration;
                    enumerator.MoveNext();
                    if (enumerator.Current != null)
                    {
                        enumerator.Current.Start(Target);

                        var ldt = dt - enumerator.Current.Duration - enumerator.Current.Elapsed;
                        enumerator.Current.Step(dt);

                        if (enumerator.Current.IsDone && ldt >= 0)
                        {
                            this.Step(ldt);
                        }
                    }
                }
                else
                {
                    var ldt = dt - enumerator.Current.Duration - enumerator.Current.Elapsed;
                    enumerator.Current.Step(dt);

                    if (enumerator.Current.IsDone && ldt >= 0)
                    {
                        this.Step(ldt);
                    }
                }
            }
        }

        public override void Reset()
        {
            base.Reset();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Reset();
            }
        }

        public override Action Clone()
        {
            var action = new SequenceAction(this.actions.Select(el => el.Clone()).ToList());
            this.CheckBindTarget(action);
            return action;
        }
    }
}
