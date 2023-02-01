using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropVec4<T>: IProp<T, Vector4>
    {
        internal Vector4 start;
        internal Vector4 end;
        internal Vector4 current;
        internal Getter<T, Vector4> getter;
        internal Setter<T, Vector4> setter;
        internal Easing easing;
        internal Progress<Vector4> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue)
        {
            if (getter == null)
            {
                throw new ArgumentNullException(nameof(getter));
            }
            else
            {
                this.getter = getter;
            }

            if (setter == null)
            {
                throw new ArgumentNullException(nameof(setter));
            }
            else
            {
                this.setter = setter;
            }

            this.end = targetValue;
            this.easing = default(Easing); 
            this.progress = null;
            this.easingFunc = null;
            this.update = null;
            this.start = Vector4.zero;
            this.current = Vector4.zero;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropVec4(Getter<T, Vector4> getter, Setter<T, Vector4> setter, Vector4 targetValue, Progress<Vector4> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public Vector4 Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return Vector4.Lerp(this.start, end, ratio);
        }

        public Vector4 End(bool relative)
        {
            if (relative)
            {
                return this.start + this.end;
            }
            else
            {
                return this.end;
            }
        }

        public void Fill(T target)
        {
            this.start = this.current = this.getter(target);
        }

        public float EasingValue(float ratio)
        {
            var nr = ratio;
            if (this.easing != Easing.Unset)
            {
                nr = EasingExecutor.Execute(ratio, this.easing);
            }
            else if (this.easingFunc != null)
            {
                nr = this.easingFunc(ratio);
            }
            return nr;
        }

        public Vector4 Progress(float ratio, bool relative)
        {
            if (this.progress != null)
            {
                current = this.progress(this.start, this.End(relative), this.current, ratio);
            }
            else
            {
                current = this.Lerp(ratio, relative);
            }
            return current;
        }

        public void Update(T target, float ratio, Vector4 current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
