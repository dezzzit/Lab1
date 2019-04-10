using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{
    class KeyHash1 : Key
    {
        public KeyHash1(int value) : base(value)
        {
        }

        public override int GetHashCode()
        {
            return 101 * ((Value >> 24) + 101 * ((Value >> 16) + 101 * (Value >> 8))) + Value;
        }
    }
}

