using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace KP.Tween
{
    public class TweenUI : Tween<VisualElement>
    {
        internal TweenUI(VisualElement target, TweenManager tm) : base(target, tm) { }

        public TweenUI MoveTo(float duration, Vector2 pos) { return  this.MoveTo(duration, pos, Easing.Unset); }

        public TweenUI MoveTo(float duration, Vector2 pos, Update<VisualElement> update) { return  this.MoveTo(duration, pos, Easing.Unset, update); }

        public TweenUI MoveTo(float duration, Vector2 pos, Easing easing) { return  this.MoveTo(duration, pos, easing, null); }

        public TweenUI MoveTo(float duration, Vector2 pos, EasingFunc easingFunc) { return  this.MoveTo(duration, pos, easingFunc, null); }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress) { return  this.MoveTo(duration, pos, progress, null); }

        public TweenUI MoveTo(float duration, Vector2 pos, Easing easing, Update<VisualElement> update) { return  this.MoveTo(duration, pos, null, easing, update); }

        public TweenUI MoveTo(float duration, Vector2 pos, EasingFunc easingFunc, Update<VisualElement> update) { return  this.MoveTo(duration, pos, null, easingFunc, update); }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress, Easing easing) { return  this.MoveTo(duration, pos, progress, easing, null); }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress, EasingFunc easingFunc) { return  this.MoveTo(duration, pos, progress, easingFunc, null); }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, update));
            return this;
        }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, easing, update));
            return this;
        }

        public TweenUI MoveTo(float duration, Vector2 pos, Progress<Vector2> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, easingFunc, update));
            return this;
        }

        public TweenUI MoveBy(float duration, Vector2 pos) { return  this.MoveBy(duration, pos, Easing.Unset); }

        public TweenUI MoveBy(float duration, Vector2 pos, Update<VisualElement> update) { return  this.MoveBy(duration, pos, Easing.Unset, update); }

        public TweenUI MoveBy(float duration, Vector2 pos, Easing easing) { return  this.MoveBy(duration, pos, easing, null); }

        public TweenUI MoveBy(float duration, Vector2 pos, EasingFunc easingFunc) { return  this.MoveBy(duration, pos, easingFunc, null); }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress) { return  this.MoveBy(duration, pos, progress, null); }

        public TweenUI MoveBy(float duration, Vector2 pos, Easing easing, Update<VisualElement> update) { return  this.MoveBy(duration, pos, null, easing, update); }

        public TweenUI MoveBy(float duration, Vector2 pos, EasingFunc easingFunc, Update<VisualElement> update) { return  this.MoveBy(duration, pos, null, easingFunc, update); }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress, Easing easing) { return  this.MoveBy(duration, pos, progress, easing, null); }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress, EasingFunc easingFunc) { return  this.MoveBy(duration, pos, progress, easingFunc, null); }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress, Update<VisualElement> update)
        {
            this.By(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, update));
            return this;
        }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress, Easing easing, Update<VisualElement> update)
        {
            this.By(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, easing, update));
            return this;
        }

        public TweenUI MoveBy(float duration, Vector2 pos, Progress<Vector2> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.By(duration, new PropVec2<VisualElement>((t) => t.transform.position, (t, v) => t.transform.position = v, pos, progress, easingFunc, update));
            return this;
        }

        public TweenUI ScaleTo(float duration, Vector3 scale) { return  this.ScaleTo(duration, scale, Easing.Unset); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Update<VisualElement> update) { return  this.ScaleTo(duration, scale, Easing.Unset, update); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Easing easing) { return  this.ScaleTo(duration, scale, easing, null); }

        public TweenUI ScaleTo(float duration, Vector3 scale, EasingFunc easingFunc) { return  this.ScaleTo(duration, scale, easingFunc, null); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress) { return  this.ScaleTo(duration, scale, progress, null); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Easing easing, Update<VisualElement> update) { return  this.ScaleTo(duration, scale, null, easing, update); }

        public TweenUI ScaleTo(float duration, Vector3 scale, EasingFunc easingFunc, Update<VisualElement> update) { return  this.ScaleTo(duration, scale, null, easingFunc, update); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress, Easing easing) { return  this.ScaleTo(duration, scale, progress, easing, null); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress, EasingFunc easingFunc) { return  this.ScaleTo(duration, scale, progress, easingFunc, null); }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, update));
            return this;
        }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, easing, update));
            return this;
        }

        public TweenUI ScaleTo(float duration, Vector3 scale, Progress<Vector3> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, easingFunc, update));
            return this;
        }

        public TweenUI ScaleBy(float duration, Vector3 scale) { return  this.ScaleBy(duration, scale, Easing.Unset); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Update<VisualElement> update) { return  this.ScaleBy(duration, scale, Easing.Unset, update); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Easing easing) { return  this.ScaleBy(duration, scale, easing, null); }

        public TweenUI ScaleBy(float duration, Vector3 scale, EasingFunc easingFunc) { return  this.ScaleBy(duration, scale, easingFunc, null); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress) { return  this.ScaleBy(duration, scale, progress, null); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Easing easing, Update<VisualElement> update) { return  this.ScaleBy(duration, scale, null, easing, update); }

        public TweenUI ScaleBy(float duration, Vector3 scale, EasingFunc easingFunc, Update<VisualElement> update) { return  this.ScaleBy(duration, scale, null, easingFunc, update); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress, Easing easing) { return  this.ScaleBy(duration, scale, progress, easing, null); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress, EasingFunc easingFunc) { return  this.ScaleBy(duration, scale, progress, easingFunc, null); }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress, Update<VisualElement> update)
        {
            this.By(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, update));
            return this;
        }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress, Easing easing, Update<VisualElement> update)
        {
            this.By(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, easing, update));
            return this;
        }

        public TweenUI ScaleBy(float duration, Vector3 scale, Progress<Vector3> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.By(duration, new PropVec3<VisualElement>((t) => t.transform.scale, (t, v) => t.transform.scale = v, scale, progress, easingFunc, update));
            return this;
        }

        public TweenUI RotateTo(float duration, Quaternion rotation) { return  this.RotateTo(duration, rotation, Easing.Unset); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Update<VisualElement> update) { return  this.RotateTo(duration, rotation, Easing.Unset, update); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Easing easing) { return  this.RotateTo(duration, rotation, easing, null); }

        public TweenUI RotateTo(float duration, Quaternion rotation, EasingFunc easingFunc) { return  this.RotateTo(duration, rotation, easingFunc, null); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress) { return  this.RotateTo(duration, rotation, progress, null); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Easing easing, Update<VisualElement> update) { return  this.RotateTo(duration, rotation, null, easing, update); }

        public TweenUI RotateTo(float duration, Quaternion rotation, EasingFunc easingFunc, Update<VisualElement> update) { return  this.RotateTo(duration, rotation, null, easingFunc, update); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress, Easing easing) { return  this.RotateTo(duration, rotation, progress, easing, null); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress, EasingFunc easingFunc) { return  this.RotateTo(duration, rotation, progress, easingFunc, null); }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, update));
            return this;
        }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, easing, update));
            return this;
        }

        public TweenUI RotateTo(float duration, Quaternion rotation, Progress<Quaternion> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, easingFunc, update));
            return this;
        }

        public TweenUI RotateBy(float duration, Quaternion rotation) { return  this.RotateBy(duration, rotation, Easing.Unset); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Update<VisualElement> update) { return  this.RotateBy(duration, rotation, Easing.Unset, update); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Easing easing) { return  this.RotateBy(duration, rotation, easing, null); }

        public TweenUI RotateBy(float duration, Quaternion rotation, EasingFunc easingFunc) { return  this.RotateBy(duration, rotation, easingFunc, null); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress) { return  this.RotateBy(duration, rotation, progress, null); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Easing easing, Update<VisualElement> update) { return  this.RotateBy(duration, rotation, null, easing, update); }

        public TweenUI RotateBy(float duration, Quaternion rotation, EasingFunc easingFunc, Update<VisualElement> update) { return  this.RotateBy(duration, rotation, null, easingFunc, update); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress, Easing easing) { return  this.RotateBy(duration, rotation, progress, easing, null); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress, EasingFunc easingFunc) { return  this.RotateBy(duration, rotation, progress, easingFunc, null); }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress, Update<VisualElement> update)
        {
            this.By(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, update));
            return this;
        }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress, Easing easing, Update<VisualElement> update)
        {
            this.By(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, easing, update));
            return this;
        }

        public TweenUI RotateBy(float duration, Quaternion rotation, Progress<Quaternion> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.By(duration, new PropQuat<VisualElement>((t) => t.transform.rotation, (t, v) => t.transform.rotation = v, rotation, progress, easingFunc, update));
            return this;
        }

        public TweenUI FadeTo(float duration, float opacity) { return  this.FadeTo(duration, opacity, Easing.Unset); }

        public TweenUI FadeTo(float duration, float opacity, Update<VisualElement> update) { return  this.FadeTo(duration, opacity, Easing.Unset, update); }

        public TweenUI FadeTo(float duration, float opacity, Easing easing) { return  this.FadeTo(duration, opacity, easing, null); }

        public TweenUI FadeTo(float duration, float opacity, EasingFunc easingFunc) { return  this.FadeTo(duration, opacity, easingFunc, null); }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress) { return  this.FadeTo(duration, opacity, progress, null); }

        public TweenUI FadeTo(float duration, float opacity, Easing easing, Update<VisualElement> update) { return  this.FadeTo(duration, opacity, null, easing, update); }

        public TweenUI FadeTo(float duration, float opacity, EasingFunc easingFunc, Update<VisualElement> update) { return  this.FadeTo(duration, opacity, null, easingFunc, update); }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress, Easing easing) { return  this.FadeTo(duration, opacity, progress, easing, null); }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress, EasingFunc easingFunc) { return  this.FadeTo(duration, opacity, progress, easingFunc, null); }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, update));
            return this;
        }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, easing, update));
            return this;
        }

        public TweenUI FadeTo(float duration, float opacity, Progress<float> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, easingFunc, update));
            return this;
        }

        public TweenUI FadeBy(float duration, float opacity) { return  this.FadeBy(duration, opacity, Easing.Unset); }

        public TweenUI FadeBy(float duration, float opacity, Update<VisualElement> update) { return  this.FadeBy(duration, opacity, Easing.Unset, update); }

        public TweenUI FadeBy(float duration, float opacity, Easing easing) { return  this.FadeBy(duration, opacity, easing, null); }

        public TweenUI FadeBy(float duration, float opacity, EasingFunc easingFunc) { return  this.FadeBy(duration, opacity, easingFunc, null); }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress) { return  this.FadeBy(duration, opacity, progress, null); }

        public TweenUI FadeBy(float duration, float opacity, Easing easing, Update<VisualElement> update) { return  this.FadeBy(duration, opacity, null, easing, update); }

        public TweenUI FadeBy(float duration, float opacity, EasingFunc easingFunc, Update<VisualElement> update) { return  this.FadeBy(duration, opacity, null, easingFunc, update); }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress, Easing easing) { return  this.FadeBy(duration, opacity, progress, easing, null); }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress, EasingFunc easingFunc) { return  this.FadeBy(duration, opacity, progress, easingFunc, null); }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress, Update<VisualElement> update)
        {
            this.By(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, update));
            return this;
        }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress, Easing easing, Update<VisualElement> update)
        {
            this.By(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, easing, update));
            return this;
        }

        public TweenUI FadeBy(float duration, float opacity, Progress<float> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.By(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, opacity, progress, easingFunc, update));
            return this;
        }

        public TweenUI FadeIn(float duration) { return  this.FadeIn(duration, Easing.Unset); }

        public TweenUI FadeIn(float duration, Update<VisualElement> update) { return  this.FadeIn(duration, Easing.Unset, update); }

        public TweenUI FadeIn(float duration, Easing easing) { return  this.FadeIn(duration, easing, null); }

        public TweenUI FadeIn(float duration, EasingFunc easingFunc) { return  this.FadeIn(duration, easingFunc, null); }

        public TweenUI FadeIn(float duration, Progress<float> progress) { return  this.FadeIn(duration, progress, null); }

        public TweenUI FadeIn(float duration, Easing easing, Update<VisualElement> update) { return  this.FadeIn(duration, null, easing, update); }

        public TweenUI FadeIn(float duration, EasingFunc easingFunc, Update<VisualElement> update) { return  this.FadeIn(duration, null, easingFunc, update); }

        public TweenUI FadeIn(float duration, Progress<float> progress, Easing easing) { return  this.FadeIn(duration, progress, easing, null); }

        public TweenUI FadeIn(float duration, Progress<float> progress, EasingFunc easingFunc) { return  this.FadeIn(duration, progress, easingFunc, null); }

        public TweenUI FadeIn(float duration, Progress<float> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 1, progress, update));
            return this;
        }

        public TweenUI FadeIn(float duration, Progress<float> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 1, progress, easing, update));
            return this;
        }

        public TweenUI FadeIn(float duration, Progress<float> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 1, progress, easingFunc, update));
            return this;
        }

        public TweenUI FadeOut(float duration) { return  this.FadeOut(duration, Easing.Unset); }

        public TweenUI FadeOut(float duration, Update<VisualElement> update) { return  this.FadeOut(duration, Easing.Unset, update); }

        public TweenUI FadeOut(float duration, Easing easing) { return  this.FadeOut(duration, easing, null); }

        public TweenUI FadeOut(float duration, EasingFunc easingFunc) { return  this.FadeOut(duration, easingFunc, null); }

        public TweenUI FadeOut(float duration, Progress<float> progress) { return  this.FadeOut(duration, progress, null); }

        public TweenUI FadeOut(float duration, Easing easing, Update<VisualElement> update) { return  this.FadeOut(duration, null, easing, update); }

        public TweenUI FadeOut(float duration, EasingFunc easingFunc, Update<VisualElement> update) { return  this.FadeOut(duration, null, easingFunc, update); }

        public TweenUI FadeOut(float duration, Progress<float> progress, Easing easing) { return  this.FadeOut(duration, progress, easing, null); }

        public TweenUI FadeOut(float duration, Progress<float> progress, EasingFunc easingFunc) { return  this.FadeOut(duration, progress, easingFunc, null); }

        public TweenUI FadeOut(float duration, Progress<float> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 0, progress, update));
            return this;
        }

        public TweenUI FadeOut(float duration, Progress<float> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 0, progress, easing, update));
            return this;
        }

        public TweenUI FadeOut(float duration, Progress<float> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 0, progress, easingFunc, update));
            return this;
        }

        public TweenUI Blink(float duration, int times)
        {
            return this.Blink(duration, times, Easing.Unset);
        }

        public TweenUI Blink(float duration, int times, Easing easing)
        {
            return this.Blink(duration, times, (t)=>
            {
                return EasingExecutor.Execute(t, easing);
            });
        }

        public TweenUI Blink(float duration, int times, EasingFunc easingFunc)
        {
            var slice = 1.0 / times;
            this.To(duration, new PropFloat<VisualElement>((t) => t.resolvedStyle.opacity, (t, v) => t.style.opacity = v, 0, (start, end, current, t) =>
            {
                if (t >= 1)
                {
                    return start;
                }
                else
                {
                    var m = t % slice;
                    return (m > (slice / 2)) ? 1 : 0;
                }
            }, easingFunc));
            return this;
        }

        private Color GetColor(VisualElement ve)
        {
            if (ve.resolvedStyle.backgroundImage!=null)
            {
                return ve.resolvedStyle.unityBackgroundImageTintColor;
            }
            else
            {
                return ve.resolvedStyle.backgroundColor;
            }
        }

        private void SetColor(VisualElement ve, Color color)
        {
            if (ve.resolvedStyle.backgroundImage != null)
            {
                ve.style.unityBackgroundImageTintColor = color;
            }
            else
            {
                ve.style.backgroundColor = color;
            }
        }

        public TweenUI TintTo(float duration, Color color) { return  this.TintTo(duration, color, Easing.Unset); }

        public TweenUI TintTo(float duration, Color color, Update<VisualElement> update) { return  this.TintTo(duration, color, Easing.Unset, update); }

        public TweenUI TintTo(float duration, Color color, Easing easing) { return  this.TintTo(duration, color, easing, null); }

        public TweenUI TintTo(float duration, Color color, EasingFunc easingFunc) { return  this.TintTo(duration, color, easingFunc, null); }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress) { return  this.TintTo(duration, color, progress, null); }

        public TweenUI TintTo(float duration, Color color, Easing easing, Update<VisualElement> update) { return  this.TintTo(duration, color, null, easing, update); }

        public TweenUI TintTo(float duration, Color color, EasingFunc easingFunc, Update<VisualElement> update) { return  this.TintTo(duration, color, null, easingFunc, update); }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress, Easing easing) { return  this.TintTo(duration, color, progress, easing, null); }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress, EasingFunc easingFunc) { return  this.TintTo(duration, color, progress, easingFunc, null); }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress, Update<VisualElement> update)
        {
            this.To(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, update));
            return this;
        }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress, Easing easing, Update<VisualElement> update)
        {
            this.To(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, easing, update));
            return this;
        }

        public TweenUI TintTo(float duration, Color color, Progress<Color> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.To(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, easingFunc, update));
            return this;
        }

        public TweenUI TintBy(float duration, Color color) { return  this.TintBy(duration, color, Easing.Unset); }

        public TweenUI TintBy(float duration, Color color, Update<VisualElement> update) { return  this.TintBy(duration, color, Easing.Unset, update); }

        public TweenUI TintBy(float duration, Color color, Easing easing) { return  this.TintBy(duration, color, easing, null); }

        public TweenUI TintBy(float duration, Color color, EasingFunc easingFunc) { return  this.TintBy(duration, color, easingFunc, null); }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress) { return  this.TintBy(duration, color, progress, null); }

        public TweenUI TintBy(float duration, Color color, Easing easing, Update<VisualElement> update) { return  this.TintBy(duration, color, null, easing, update); }

        public TweenUI TintBy(float duration, Color color, EasingFunc easingFunc, Update<VisualElement> update) { return  this.TintBy(duration, color, null, easingFunc, update); }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress, Easing easing) { return this.TintBy(duration, color, progress, easing, null); }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress, EasingFunc easingFunc) { return this.TintBy(duration, color, progress, easingFunc, null); }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress, Update<VisualElement> update)
        {
            this.By(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, update));
            return this;
        }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress, Easing easing, Update<VisualElement> update)
        {
            this.By(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, easing, update));
            return this;
        }

        public TweenUI TintBy(float duration, Color color, Progress<Color> progress, EasingFunc easingFunc, Update<VisualElement> update)
        {
            this.By(duration, new PropColor<VisualElement>((t) => this.GetColor(t), (t, v) => this.SetColor(t, v), color, progress, easingFunc, update));
            return this;
        }

        public TweenUI FlipX()
        {
            this.Call((t) =>
            {
                t.transform.scale = new Vector3(t.transform.scale.x * -1, t.transform.scale.y);
            });
            return this;
        }

        public TweenUI FlipY()
        {
            this.Call((t) =>
            {
                t.transform.scale = new Vector3(t.transform.scale.x, t.transform.scale.y * -1);
            });
            return this;
        }

        public TweenUI Place(Vector2 pos)
        {
            this.Set(new PropVec2<VisualElement>((t)=>t.transform.position, (t, v)=> t.transform.position = v, pos));
            return this;
        }

        public TweenUI Hide()
        {
            this.Set(new PropInt<VisualElement>((t) => (int)t.resolvedStyle.visibility, (t, v) => t.style.visibility = (Visibility)v, 1));
            return this;
        }

        public TweenUI Show()
        {
            this.Set(new PropInt<VisualElement>((t) => (int)t.resolvedStyle.visibility, (t, v) => t.style.visibility = (Visibility)v, 0));
            return this;
        }

        public TweenUI ToggleVisible()
        {
            this.Call((t)=>
            {
                t.style.visibility = t.resolvedStyle.visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            });
            return this;
        }

        public TweenUI RemoveSelf()
        {
            this.Call((t) =>
            {
                t.RemoveFromHierarchy();
            });
            return this;
        }

        public new TweenUI Then(Tween tween)
        {
            var action = tween.UnionInternalWithTarget();
            this.actions.Add(action);
            return this;
        }

        public new TweenUI Sequence(params Tween[] tweens)
        {
            Action[] actions = tweens.Select(el => el.UnionInternalWithTarget()).ToArray();
            var action = new SequenceAction(actions);
            this.actions.Add(action);
            return this;
        }

        public new TweenUI Parallel(params Tween[] tweens)
        {
            List<Action> actions = tweens.Select(el => el.UnionInternalWithTarget()).ToList();
            this.actions.Add(new ParallelAction(actions));
            return this;
        }

        public new TweenUI Delay(float duration)
        {
            this.actions.Add(new DelayAction(duration));
            return this;
        }

        public new TweenUI Repeat(int times)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatAction(action, times));
            return this;
        }

        public new TweenUI RepeatForEver()
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new RepeatForEverAction(action));
            return this;
        }

        public new TweenUI Speed(float speed)
        {
            var action = UnionInternal();
            this.actions.Clear();
            this.actions.Add(new SpeedAction(action, speed));
            return this;
        }

        public new TweenUI To<D>(float duration, IProp<VisualElement, D> prop) where D : struct
        {
            var action = new ToAction<VisualElement, D>(duration, prop);
            this.actions.Add(action);
            return this;
        }

        public new TweenUI By<D>(float duration, IProp<VisualElement, D> prop) where D : struct
        {
            var action = new ByAction<VisualElement, D>(duration, prop);
            this.actions.Add(action);
            return this;
        }

        public new TweenUI Set<D>(IProp<VisualElement, D> prop) where D : struct
        {
            var action = new SetAction<VisualElement, D>(prop);
            this.actions.Add(action);
            return this;
        }

        public new TweenUI Call(CallFunc<VisualElement> callFunc)
        {
            var action = new CallAction<VisualElement>(callFunc);
            this.actions.Add(action);
            return this;
        }

        public override Tween Clone()
        {
            var tween = new TweenUI(this.target, this.tm);
            tween.actions = this.actions.Select(el => el.Clone()).ToList();
            return tween;
        }
    }
}
