using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_HashTable
{

    public class BucketsHashTable<K,V>:ICustomHashTable<K, V>
    {
        const int InitStorageSize = 1000;
        const int InitBucketSize = 1000;

        private int _bucketSize;
        protected int GetArrayPosition(K key)
        {
            var position = key.GetHashCode() % InitStorageSize;
            return Math.Abs(position);
        }

        KeyValue<K,V>[][] _coreStorage = new KeyValue<K, V>[InitStorageSize][];

        public BucketsHashTable()
        {

            //init buckets
            _bucketSize = InitBucketSize;
            for (int i = 0; i < InitStorageSize; i++)
            {
                _coreStorage[i] = new KeyValue<K, V>[InitBucketSize];
            }
            
        }

        private void IncreaseBucketsCapacity()
        {
            const int step = 1000;
            _bucketSize = _bucketSize + step;
            for (int i = 0; i < _coreStorage.Length; i++)
            {
                var expandedBucket = new KeyValue<K, V>[_bucketSize];
                for (int j = 0; j < _coreStorage[i].Length; j++)
                {
                    expandedBucket[i] = _coreStorage[i][j];
                }

                _coreStorage[i] = expandedBucket;
            }
        }

        public void Add(KeyValue<K, V> item)
        {
            int lastBucketElementPos = -1;
            var index = GetArrayPosition(item.Key);
            
            while (_coreStorage[index].Length>0)
            {

                for (int i = 0; i < _coreStorage[index].Length; i++)
                {
                    
                    if (_coreStorage[index][i].Key == null)
                    {
                        break;
                    }
                    if (_coreStorage[index][i].Key.Equals(item.Key))
                    {
                        throw new ArgumentException($"Key has already added'{item.Key}'");
                    }
                    lastBucketElementPos = i;

                }

                
                break;
            }

            if (lastBucketElementPos+1 >= _bucketSize)
            {
                IncreaseBucketsCapacity();
            }
            _coreStorage[index][lastBucketElementPos+1] = item;
        }

        public void Add(K key, V value)
        {
            Add(new KeyValue<K, V>(key,value));
        }

    }

}
