using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropInt<T>: IProp<T, int>
    {
        internal int start;
        internal int end;
        internal int current;
        internal Getter<T, int> getter;
        internal Setter<T, int> setter;
        internal Easing easing;
        internal Progress<int> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue)
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

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropInt(Getter<T, int> getter, Setter<T, int> setter, int targetValue, Progress<int> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public int Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return (int)(this.start + (end - this.start) * ratio);
        }

        public int End(bool relative)
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

        public int Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, int current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
