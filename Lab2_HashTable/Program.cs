using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Lab2_HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //BucketsHashTable<KeyHash1,string> bucketsHashTableKeyHash1 = new BucketsHashTable<KeyHash1, string>();
            //BucketsHashTable<KeyHash2, string> bucketsHashTableKeyHash2 = new BucketsHashTable<KeyHash2, string>();
            //BucketsHashTable<KeyConst, string> bucketsHashTableKeyConst = new BucketsHashTable<KeyConst, string>();

            //ResizingHashTable<KeyHash1, string> resizingHashTableKeyHash1 = new ResizingHashTable<KeyHash1, string>();
            //ResizingHashTable<KeyHash2, string> resizingHashTableKeyHash2 = new ResizingHashTable<KeyHash2, string>();
            //ResizingHashTable<KeyConst, string> resizingHashTableKeyConst = new ResizingHashTable<KeyConst, string>();
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    bucketsHashTableKeyHash1.Add(new KeyHash1(i),i.ToString());
            //}

            var summary = BenchmarkRunner.Run<HashTableChecker<BucketsHashTable<Key,object>>>();
            Console.ReadKey();
        }
    }
}
