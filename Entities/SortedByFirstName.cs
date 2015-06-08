using System;
using System.Collections.Generic;
using System.Globalization;

namespace Entities
{
    public class SortedByFirstName<T> : Comparer<T> where T : IPerson
    {
        public override int Compare(T x, T y)
        {
            if (x == null)
            {
                throw new ArgumentException("X");
            } 

            if (y == null)
            {
                throw new ArgumentException("Y");
            }
            return String.Compare(x.FirstName, y.FirstName, false, CultureInfo.CurrentCulture);
        }
    }
}
