using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Transactions
{
	class Program
	{
		static void Main(string[] args)
		{
            var testDictionary = new Dictionary<int, string>();
          var  wrapper =  new CuncurentDictionaryWrapper<int, String>(testDictionary);
            //wrapper.BeginTransaction();
            //wrapper.Add(1,"1");
            //wrapper.Add(2,"2");
            //var test1 = wrapper.Get(2);
            //Console.Write(test1);
            //wrapper.Rollback();
            //test1 = wrapper.Get(2);
            //Console.Write(test1);

            //wrapper.Add(1, "1");
            //wrapper.Add(2, "2");
            //wrapper.Remove(1);
            //wrapper.Commit();
            //var test2 = wrapper.Get(1);

            Task testTask1 = new Task(() =>
            {
                wrapper.Add(3, "3");
                wrapper.Add(4, "4");
                var test3 = wrapper.Get(2);
                Console.Write(test3);
                wrapper.Commit();
            });

            Task testTask2 = new Task(() =>
            {
                wrapper.Add(5, "5");
                wrapper.Remove(2);
                var test3 = wrapper.Get(2);
                Console.Write(test3);
                wrapper.Commit();
            });

            Task testTask3 = new Task(() =>
            {
                wrapper.Add(6, "5");
                wrapper.Remove(2);
                var test3 = wrapper.Get(2);
                Console.Write(test3);
                wrapper.Rollback();
            });

            Task testTask4 = new Task(() =>
            {
                wrapper.Add(6, "5");
                var test3 = wrapper.Get(2);
                Console.Write(test3);
                wrapper.Commit();
            });

            testTask1.Start();
            testTask2.Start();
            testTask3.Start();
            testTask4.Start();

        }
	}
}
