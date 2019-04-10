using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2_HashTable;

namespace Lab2_HashTable
{
    public interface ICustomHashTable<K,V>
    {
        void Add(KeyValue<K, V> item);
        void Add(K key, V value);
    }
}
