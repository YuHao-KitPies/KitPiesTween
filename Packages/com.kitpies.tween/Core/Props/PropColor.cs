using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropColor<T>: IProp<T, Color>
    {
        internal Color start;
        internal Color end;
        internal Color current;
        internal Getter<T, Color> getter;
        internal Setter<T, Color> setter;
        internal Easing easing;
        internal Progress<Color> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue)
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
            this.start = Color.black;
            this.current = Color.black;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropColor(Getter<T, Color> getter, Setter<T, Color> setter, Color targetValue, Progress<Color> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public Color Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return Color.Lerp(this.start, end, ratio);
        }

        public Color End(bool relative)
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

        public Color Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, Color current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
