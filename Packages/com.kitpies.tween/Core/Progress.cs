using System;
namespace KP.Tween
{
    public delegate D Progress<D>(D start, D end, D current, float ratio) where D : struct;
}
