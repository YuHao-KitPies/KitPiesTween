using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KP.Tween
{
    internal class IntervalAction: Action
    {
        protected float elapsed;
        protected bool firstTick;
        protected float duration;

        public override float Elapsed { get => this.elapsed; }
        public override float Duration { get => this.duration; }
        public override bool IsDone => this.elapsed >= this.duration;

        public IntervalAction(float duration)
        {
            this.duration = duration;
            this.firstTick = true;
        }

        public override void Start(object target)
        {
            base.Start(target);
            this.elapsed = 0;
            this.firstTick = true;
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
            
            if (this.ShouldStep())
            {
                var t = Mathf.Clamp01(this.elapsed / (this.duration > float.Epsilon ? this.duration : float.Epsilon));
                this.Update(t);
            }
        }
        public override void Reset()
        {
            this.elapsed = 0;
            this.firstTick = true;
        }

        public override Action Clone()
        {
            var action = new IntervalAction(this.duration);
            this.CheckBindTarget(action);
            return action;
        }
    }
}
