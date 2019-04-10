using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{

    public class ResizingHashTable<K,V>:ICustomHashTable<K, V>
    {
        const int Size = 10000;
        protected int GetArrayPosition(K key)
        {
            var position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        KeyValue<K,V>?[] _coreStorage = new KeyValue<K, V>?[Size];

        public void Add(KeyValue<K, V> item)
        {
            var index = GetArrayPosition(item.Key);
            while (_coreStorage[index].HasValue)
            {
                if (_coreStorage[index].Value.Key.Equals(item.Key))
                {
                    throw new ArgumentException($"Key has already added'{item.Key}'");
                }

                if (++index < _coreStorage.Length) continue;
                ExpandStorage();
                break;
            }

            _coreStorage[index] = item;
        }

        private void ExpandStorage()
        {
            var expandedStorage = new KeyValue<K,V>?[_coreStorage.Length * 2];
            for (int i = 0; i < _coreStorage.Length; i++)
            {
                expandedStorage[i] = _coreStorage[i];
            }
            _coreStorage = expandedStorage;
        }
        public void Add(K key, V value)
        {
            Add(new KeyValue<K, V>(key,value));
        }

    }

}
