using System;
using UnityEngine;

namespace KP.Tween
{
    public interface IProp<T, D> where D : struct
    {
        D Lerp(float ratio, bool relative);
        D End(bool relative);
        void Fill(T target);
        float EasingValue(float ratio);
        D Progress(float ratio, bool relative);
        void Update(T target, float ratio, D current);
    }
}
