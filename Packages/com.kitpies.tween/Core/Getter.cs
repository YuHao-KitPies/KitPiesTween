using System;
namespace KP.Tween
{
    public delegate D Getter<T, out D>(T target) where D : struct;
}
