using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
namespace Lab1_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowProcessMemoryAllocation();
            PrintTotalAvailableMemory();
            PrintMaxBlockMemoryAmount();
            Console.ReadKey();

        }
        private static void PrintMaxBlockMemoryAmount()
        {
            const int mb = 1024 * 1024;
            int i = 500;

            try
            {
                for (; ; i++)
                {
                    long initSize = i * mb;
                    var testArray = new byte[initSize];

                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"Max size of single block available in heap to allocate {i} Mb");
                //Console.WriteLine($"- On GC method GetTotalMemory {GC.GetTotalMemory(false)/(1024*1024)} Mb");
                //ShowProcessMemoryAllocation();
            }

        }

        private static void PrintTotalAvailableMemory()
        {
            const int mb = 1024 * 1024;
            int i = 1;
            LinkedList<byte[]> testList = new LinkedList<byte[]>();

            try
            {
                for (; ; i++)
                {
                   
                    testList.AddLast(new byte[1*mb]);
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"1) Amount of available memory to allocate {i} Mb");
                //Console.WriteLine($"- On GC method GetTotalMemory {GC.GetTotalMemory(false) / (1024 * 1024)} Mb");
                //ShowProcessMemoryAllocation();
            }

        }

        private static void ShowProcessMemoryAllocation()
        {
            var availableMemory = 0.0;
            Process proc = Process.GetCurrentProcess();
            availableMemory = Math.Round(proc.PrivateMemorySize64 /(1024.00*1024.00), 2);
            proc.Dispose();

                Console.WriteLine($"Allocated process Memory {availableMemory} Mb");
            }
        }

        
    
}
