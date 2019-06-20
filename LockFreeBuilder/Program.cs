using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockFreeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadObjectBuilder builder = new ThreadObjectBuilder();


            Director director = new Director(builder, "Some text");
            Console.WriteLine(director.Result.StringContent);
            Console.ReadKey();

        }
    }
}
