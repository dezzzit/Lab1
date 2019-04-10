using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Lab2_HashTable
{
    [ClrJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class HashTableChecker<T> where T : ICustomHashTable<Key, object>, new()
    {

        const int size = 3_000_000;
        const string _item = "item";
        private readonly Key[] _dataDefault = new Key[size];
        private readonly KeyConst[] _dataConst = new KeyConst[size];
        private readonly KeyHash1[] _dataKeyHash1 = new KeyHash1[size];
        private readonly KeyHash2[] _dataKeyHash2 = new KeyHash2[size];
        

        [GlobalSetup]
        public void Setup()
        {
            FillArray(_dataDefault);
            FillArray(_dataConst);
            FillArray(_dataKeyHash1);
            FillArray(_dataKeyHash2);
        }


        [Benchmark]
        public void DefaultHashFunction()
        {
            BenchmarkBody(_dataDefault);
        }

        [Benchmark]
        public void ConstHashFunction()
        {
            BenchmarkBody(_dataConst);
        }

        [Benchmark]
        public void FirstHashFunction()
        {
            BenchmarkBody(_dataKeyHash1);
        }

        [Benchmark]
        public void SecondHashFunction()
        {
            BenchmarkBody(_dataKeyHash2);
        }

        private void BenchmarkBody(Key[] data)
        {
            var htable = new T();
            foreach (var key in data)
            {
                try
                {
                    htable.Add(key, _item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void FillArray<U>(U[] array) where U : Key
        {
            var rand = new Random();

            List<int> possible = Enumerable.Range(0, array.Length).OrderBy(x => rand.Next(array.Length)).ToList();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (U)Activator.CreateInstance(typeof(U), possible[i]);
            }
        }
    }
}
