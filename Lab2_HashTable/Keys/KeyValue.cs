using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{
    public struct KeyValue<K, V>
    {

        public KeyValue(K key, V value) : this()
        {
            Key = key;
            Value = value;
        }

        public K Key { get; set; }
        public V Value { get; set; }
    }
}
