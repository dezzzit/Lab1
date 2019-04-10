using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{
    public class KeyConst : Key
    {
        public KeyConst(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return 2;
        }
    }
}
