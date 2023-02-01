using System;
using UnityEngine;

namespace KP.Tween
{

    public struct PropRect<T>: IProp<T, Rect>
    {
        internal Rect start;
        internal Rect end;
        internal Rect current;
        internal Getter<T, Rect> getter;
        internal Setter<T, Rect> setter;
        internal Easing easing;
        internal Progress<Rect> progress;
        internal EasingFunc easingFunc;
        internal Update<T> update;

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue)
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
            this.start = Rect.zero;
            this.current = Rect.zero;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Easing easing): this(getter, setter, targetValue)
        {
            this.easing = easing;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.easingFunc = easingFunc;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress) : this(getter, setter, targetValue)
        {
            this.progress = progress;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Update<T> update): this(getter, setter, targetValue)
        {
            this.update = update;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Easing easing, Update<T> update) : this(getter, setter, targetValue, easing)
        {
            this.update = update;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, easingFunc)
        {
            this.update = update;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress, Update<T> update) : this(getter, setter, targetValue, progress)
        {
            this.update = update;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress, Easing easing) : this(getter, setter, targetValue)
        {
            this.easing = easing;
            this.progress = progress;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress, EasingFunc easingFunc) : this(getter, setter, targetValue)
        {
            this.progress = progress;
            this.easingFunc = easingFunc;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress, Easing easing, Update<T> update) : this(getter, setter, targetValue, progress, easing)
        {
            this.update = update;
        }

        public PropRect(Getter<T, Rect> getter, Setter<T, Rect> setter, Rect targetValue, Progress<Rect> progress, EasingFunc easingFunc, Update<T> update) : this(getter, setter, targetValue, progress, easingFunc)
        {
            this.update = update;
        }

        public Rect Lerp(float ratio, bool relative)
        {
            var end = this.End(relative);
            return new Rect(Vector2.Lerp(this.start.position, end.position, ratio), Vector2.Lerp(this.start.size, end.size, ratio));
        }

        public Rect End(bool relative)
        {
            if (relative)
            {
                return new Rect(this.start.position + this.end.position, this.start.size + this.end.size);
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

        public Rect Progress(float ratio, bool relative)
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

        public void Update(T target, float ratio, Rect current)
        {
            this.setter(target, current);
            if (this.update != null)
            {
                this.update(target, ratio);
            }
        }
    }
}
