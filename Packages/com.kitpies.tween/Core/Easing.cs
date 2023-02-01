using System;
using UnityEngine;

namespace KP.Tween
{
    public enum Easing
    {
        Unset,
        QuadIn,
        QuadOut,
        QuadInOut,
        CubicIn,
        CubicOut,
        CubicInOut,
        QuartIn,
        QuartOut,
        QuartInOut,
        QuintIn,
        QuintOut,
        QuintInOut,
        SineIn,
        SineOut,
        SineInOut,
        ExpoIn,
        ExpoOut,
        ExpoInOut,
        CircIn,
        CircOut,
        CircInOut,
        ElasticIn,
        ElasticOut,
        ElasticInOut,
        BackIn,
        BackOut,
        BackInOut,
        BounceIn,
        BounceOut,
        BounceInOut
    }

    internal static class EasingExecutor
    {
        public static float Execute(float t, Easing easing)
        {
            switch (easing)
            {
                case Easing.QuadIn: return QuadIn(t);
                case Easing.QuadOut: return QuadOut(t);
                case Easing.QuadInOut: return QuadInOut(t);
                case Easing.CubicIn: return CubicIn(t);
                case Easing.CubicOut: return CubicOut(t);
                case Easing.CubicInOut: return CubicInOut(t);
                case Easing.QuartIn: return QuartIn(t);
                case Easing.QuartOut: return QuartOut(t);
                case Easing.QuartInOut: return QuartInOut(t);
                case Easing.QuintIn: return QuintIn(t);
                case Easing.QuintOut: return QuintOut(t);
                case Easing.QuintInOut: return QuintInOut(t);
                case Easing.SineIn: return SineIn(t);
                case Easing.SineOut: return SineOut(t);
                case Easing.SineInOut: return SineInOut(t);
                case Easing.ExpoIn: return ExpoIn(t);
                case Easing.ExpoOut: return ExpoOut(t);
                case Easing.ExpoInOut: return ExpoInOut(t);
                case Easing.CircIn: return CircIn(t);
                case Easing.CircOut: return CircOut(t);
                case Easing.CircInOut: return CircInOut(t);
                case Easing.ElasticIn: return ElasticIn(t);
                case Easing.ElasticOut: return ElasticOut(t);
                case Easing.ElasticInOut: return ElasticInOut(t);
                case Easing.BackIn: return BackIn(t);
                case Easing.BackOut: return BackOut(t);
                case Easing.BackInOut: return BackInOut(t);
                case Easing.BounceIn: return BounceIn(t);
                case Easing.BounceOut: return BounceOut(t);
                case Easing.BounceInOut: return BounceInOut(t);
                default: return t;
            }
        }

        private static float QuadIn(float t)
        {
            return t * t;
        }

        private static float QuadOut(float t)
        {
            return 1 - (1 - t) * (1 - t);
        }

        private static float QuadInOut(float t)
        {
            return t < 0.5 ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
        }

        private static float CubicIn(float t)
        {
            return t * t * t;
        }

        private static float CubicOut(float t)
        {
            return 1 - Mathf.Pow(1 - t, 3);
        }

        private static float CubicInOut(float t)
        {
            return t < 0.5 ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
        }

        private static float QuartIn(float t)
        {
            return t * t * t * t;
        }

        private static float QuartOut(float t)
        {
            return 1 - Mathf.Pow(1 - t, 4);
        }

        private static float QuartInOut(float t)
        {
            return t < 0.5 ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
        }

        private static float QuintIn(float t)
        {
            return t * t * t * t * t;
        }

        private static float QuintOut(float t)
        {
            return 1 - Mathf.Pow(1 - t, 5);
        }

        private static float QuintInOut(float t)
        {
            return t < 0.5 ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
        }

        private static float SineIn(float t)
        {
            return 1 - Mathf.Cos((t * Mathf.PI) / 2);
        }

        private static float SineOut(float t)
        {
            return Mathf.Sin((t * Mathf.PI) / 2);
        }

        private static float SineInOut(float t)
        {
            return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
        }

        private static float ExpoIn(float t)
        {
            return t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);
        }

        private static float ExpoOut(float t)
        {
            return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
        }

        private static float ExpoInOut(float t)
        {
            return t == 0
                      ? 0
                      : t == 1
                      ? 1
                      : t < 0.5 ? Mathf.Pow(2, 20 * t - 10) / 2
                      : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
        }

        private static float CircIn(float t)
        {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
        }

        private static float CircOut(float t)
        {
            return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
        }

        private static float CircInOut(float t)
        {
            return t < 0.5
                      ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2
                      : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
        }

        private static float ElasticIn(float t)
        {
            float c4 = (2 * Mathf.PI) / 3;

            return t == 0
                      ? 0
                      : t == 1
                      ? 1
                      : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
        }

        private static float ElasticOut(float t)
        {
            float c4 = (2 * Mathf.PI) / 3;

            return t == 0
                      ? 0
                      : t == 1
                      ? 1
                      : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        }

        private static float ElasticInOut(float t)
        {
            float c5 = (2 * Mathf.PI) / 4.5f;

            return t == 0
                      ? 0
                      : t == 1
                      ? 1
                      : t < 0.5
                      ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                      : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
        }

        private static float BackIn(float t)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return c3 * t * t * t - c1 * t * t;
        }

        private static float BackOut(float t)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }

        private static float BackInOut(float t)
        {
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            return t < 0.5
                      ? (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
                      : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
        }

        private static float BounceIn(float t)
        {
            return 1 - BounceOut(1 - t);
        }

        private static float BounceOut(float t)
        {
            float n1 = 7.5625f;
            float d1 = 2.75f;

            if (t < 1 / d1)
            {
                return n1 * t * t;
            }
            else if (t < 2 / d1)
            {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            }
            else if (t < 2.5 / d1)
            {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            }
            else
            {
                return n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }
        }

        private static float BounceInOut(float t)
        {
            return t < 0.5
                      ? (1 - BounceOut(1 - 2 * t)) / 2
                      : (1 + BounceOut(2 * t - 1)) / 2;
        }
    }
}
