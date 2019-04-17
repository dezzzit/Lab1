using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Unions
{
    public static class ListUnionExtentions
    {
        public static void MyUnion<T>(this List<T> x, List<T> y) where T : Apartment
        {
            var apCompare = new ApartmentComparer<T>();
            var setX  = new HashSet<T>(x, apCompare);
            setX.UnionWith(y);
            x.Clear();
            x.AddRange(setX);
        }

        public static void MyUnionAll<T>(this List<T> x, List<T> y)
        {
           x.AddRange(y);
        }
    }

   
}
