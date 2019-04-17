using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Unions
{
    public class ApartmentComparer<T>: IEqualityComparer<T>
    where T:Apartment
    {
        public bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name
                   && Math.Abs(x.Latitude - y.Latitude) < 0.01 &&
                   Math.Abs(x.Longitude - y.Longitude) < 0.01;
        }

        public int GetHashCode(T apartment)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (apartment.Name ?? string.Empty).GetHashCode();
                hash = hash * 23 + apartment.Latitude.GetHashCode();
                hash = hash * 23 + apartment.Longitude.GetHashCode();
                return hash;
            }

        }
    }
}
