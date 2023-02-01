using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace KP.Tween
{
    public class TweenManager
    {
        private static readonly long RefreshInterval = 16;
        private VisualElement root;
        private IVisualElementScheduledItem updateTask;
        private Dictionary<object, List<Tween>> tweenItems = new Dictionary<object, List<Tween>>();

        internal TweenManager(VisualElement root)
        {
            if (root != null)
            {
                this.root = root;

                this.updateTask = this.root.schedule.Execute(this.Update).Every(RefreshInterval);
            }
            else
            {
                throw new ArgumentNullException(nameof(root));
            }
        }

        private void StepTweensForTarget(object target, float dt)
        {
            var tweens = tweenItems[target];

            for (var i = 0; i < tweens.Count; i++)
            {
                VisualElement ve = target as VisualElement;
                if (ve != null && !ve.enabledInHierarchy) continue;
                var t = tweens[i];
                t.Step(dt);
            }
        }

        private void PurgeTweensForTarget(object target)
        {
            var tweens = tweenItems[target];
            var doneTweens = tweens.Where(el => el.IsDone()).ToList();
            for (var j = 0; j < doneTweens.Count; j++)
            {
                doneTweens[j].Finish();
            }
        }

        internal void AddATween(Tween tween)
        {
            var target = tween.Target;
            if (!this.tweenItems.ContainsKey(target))
            {
                this.tweenItems.Add(target, new List<Tween>() { tween });
            }
            else
            {
                var tweens = this.tweenItems[target];
                tweens.Add(tween);
                this.tweenItems[target] = tweens;
            }
        }

        internal void RemoveATween(Tween tween)
        {
            var target = tween.Target;
            if (this.tweenItems.ContainsKey(target))
            {
                var tweens = this.tweenItems[target];
                tweens.Remove(tween);

                if (tweens.Count > 0)
                {
                    this.tweenItems[target] = tweens;
                }
                else
                {
                    this.tweenItems.Remove(target);
                }
            }
        }

        public static TweenManager Init(VisualElement root)
        {
            return new TweenManager(root);
        }

        public Tween<T> Tween<T>(T target)
        {
            return new Tween<T>(target, this);
        }

        public TweenUI TweenUI(VisualElement target)
        {
            return new TweenUI(target, this);
        }

        private void Update(TimerState timerState)
        {
            var t = timerState.deltaTime / 1000f;
            for (var i = 0; i < tweenItems.Keys.Count; i ++)
            {
                var target = tweenItems.Keys.ElementAt(i);

                this.StepTweensForTarget(target, t);

                this.PurgeTweensForTarget(target);
            }
        }

        public void PauseAll()
        {
            for (var i = 0; i < tweenItems.Keys.Count; i++)
            {
                var target = tweenItems.Keys.ElementAt(i);
                this.PauseAllForTarget(target);
            }
        }

        public void ResumeAll()
        {
            for (var i = 0; i < tweenItems.Keys.Count; i++)
            {
                var target = tweenItems.Keys.ElementAt(i);
                this.ResumeAllForTarget(target);
            }
        }

        public void StopAll()
        {
            var targets = this.tweenItems.Keys.ToList();
            for (var i = 0; i < targets.Count; i++)
            {
                this.StopAllForTarget(targets[i]);
            }
        }

        public void StopAllForTarget<T>(T target)
        {
            if (this.tweenItems.TryGetValue(target, out List<Tween> tweens))
            {
                while (tweens.Count > 0)
                {
                    tweens[0].Stop();
                }
            }
        }

        public void PauseAllForTarget<T>(T target)
        {
            if (this.tweenItems.TryGetValue(target, out List<Tween> tweens))
            {
                tweens.ForEach(el =>
                {
                    el.PauseInGloble();
                });
            }
        }

        public void ResumeAllForTarget<T>(T target)
        {
            if (this.tweenItems.TryGetValue(target, out List<Tween> tweens))
            {
                tweens.ForEach(el =>
                {
                    el.ResumeInGloble();
                });
            }
        }
    }
}
