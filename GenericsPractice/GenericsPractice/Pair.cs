using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsPractice
{
    public class Pair<S, T>
    {
        public S Key { get; set; }
        public T Value { get; set; }
        public Pair(S key, T value)
        {
            Key = key;
            Value = value;
        }

        public T this[S key]
        {
            get => Value;
            set
            {
                Key = key;
                Value = value;
            }
        }
    }
}