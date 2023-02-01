using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropFloat<T>: IProp<T, float>
    {
        internal float start;
        internal float end;
        internal float current;
        internal Getter<T, float> getter;
        internal Setter<T, float> setter;
        internal Easing easing;
        internal Progress<float> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue)
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
            this.start = 0;
            this.current = 0;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropFloat(Getter<T, float> getter, Setter<T, float> setter, float targetValue, Progress<float> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public float Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return this.start + (end - this.start) * ratio;
        }

        public float End(bool relative)
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

        public float Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, float current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
