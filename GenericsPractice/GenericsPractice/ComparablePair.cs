using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice
{
    public class ComparablePair<T, U> : IComparable<ComparablePair<T, U>> 
    where T: IComparable<T>
    where U: IComparable<U>
    {
        public T TValue { get; set; }
        public U UValue { get; set; }
        public ComparablePair(T valueT, U valueU)
        {
            TValue = valueT;
            UValue = valueU;
        }
        public int CompareTo(ComparablePair<T, U>? other)
        {
            return TValue.CompareTo(other.TValue) != 0 ? TValue.CompareTo(other.TValue) : UValue.CompareTo(other.UValue);
        }
    }
}