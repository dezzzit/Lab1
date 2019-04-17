using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using FileHelpers;

namespace Lab3_Unions
{
    class Program
    {

        static void Main(string[] args)
        {
            //CollectionUnionManager.UnionCollection();
            //CollectionUnionManager.UnionAllCollection();

            var summary = BenchmarkRunner.Run<CollectionUnionManager>();
            Console.ReadKey();
        }

       



    }
}
