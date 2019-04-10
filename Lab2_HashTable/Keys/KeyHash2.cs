using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{
    public class KeyHash2:Key
    {
        public KeyHash2(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return ((Value >> 16) ^ Value) * 0x45d9f3b;
        }
    }
}
