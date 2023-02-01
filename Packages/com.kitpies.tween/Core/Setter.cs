using System;
namespace KP.Tween
{
    public delegate void Setter<T, in D>(T target, D value) where D: struct;
}
