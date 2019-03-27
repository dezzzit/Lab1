using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (true)
            {
                
                i++;
                var testArray = new byte[i];
                var totalMemory = GC.GetTotalMemory(false);
            }
            Console.WriteLine();

            Console.ReadKey();

    }
}
}
