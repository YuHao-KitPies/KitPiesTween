using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropQuat<T>: IProp<T, Quaternion>
    {
        internal Quaternion start;
        internal Quaternion end;
        internal Quaternion current;
        internal Getter<T, Quaternion> getter;
        internal Setter<T, Quaternion> setter;
        internal Easing easing;
        internal Progress<Quaternion> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue)
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
            this.start = Quaternion.identity;
            this.current = Quaternion.identity;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropQuat(Getter<T, Quaternion> getter, Setter<T, Quaternion> setter, Quaternion targetValue, Progress<Quaternion> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public Quaternion Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return Quaternion.Lerp(this.start, end, ratio);
        }

        public Quaternion End(bool relative)
        {
            if (relative)
            {
                return this.start * this.end;
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

        public Quaternion Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, Quaternion current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
