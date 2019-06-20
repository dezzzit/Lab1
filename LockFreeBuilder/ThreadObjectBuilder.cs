using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LockFreeBuilder
{
    public class ThreadObjectBuilder:IBuilder
    {
        private static volatile int _lockVersion = 0;
        private readonly Dictionary<int, ThreadObject> _threadObjectsPool = new Dictionary<int, ThreadObject>();
      

        public ThreadObject CreateAndGetResults(string content)
        {
            ThreadObject obj;
            if(_threadObjectsPool.TryGetValue(Thread.CurrentThread.ManagedThreadId, out obj))
            {
                return obj;
            }

            obj = new ThreadObject() {StringContent = content};
            while (_lockVersion + 1 != Interlocked.Increment(ref _lockVersion))
            {
                _threadObjectsPool.Add(Thread.CurrentThread.ManagedThreadId, new ThreadObject { StringContent = content });
                Thread.Sleep(1);
            }

            return obj;
        }
    }
}
