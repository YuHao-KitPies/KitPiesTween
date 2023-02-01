using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropVec3<T>: IProp<T, Vector3>
    {
        internal Vector3 start;
        internal Vector3 end;
        internal Vector3 current;
        internal Getter<T, Vector3> getter;
        internal Setter<T, Vector3> setter;
        internal Easing easing;
        internal Progress<Vector3> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue)
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
            this.start = Vector3.zero;
            this.current = Vector3.zero;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropVec3(Getter<T, Vector3> getter, Setter<T, Vector3> setter, Vector3 targetValue, Progress<Vector3> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public Vector3 Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return Vector3.Lerp(this.start, end, ratio);
        }

        public Vector3 End(bool relative)
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

        public Vector3 Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, Vector3 current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
