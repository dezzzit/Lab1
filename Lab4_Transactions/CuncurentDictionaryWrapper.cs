using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4_Transactions
{
	public class CuncurentDictionaryWrapper<K,V>
	{
        private static object syncRoot = new object();

        private Dictionary<K,V> _set;
		//key - thread id, value - shadow set
		private Dictionary<int, Dictionary<K, V>> _transactionShadowSets = new Dictionary<int, Dictionary<K, V>>();
        //key - thread id, value - action
        private Dictionary<int, Queue<Action>> _transactionEventsLog = new Dictionary<int, Queue<Action>>();
        public CuncurentDictionaryWrapper(Dictionary<K, V> set)
		{
			_set = set;
		}

        public CuncurentDictionaryWrapper()
        {
            _set = new Dictionary<K, V>();
        }

        public void Add(K key, V item)
        {
            Dictionary<K, V> shadowSet = null;
            if (_transactionShadowSets.TryGetValue(Thread.CurrentThread.ManagedThreadId, out shadowSet))
            {
                shadowSet.Add(key, item);
                _transactionEventsLog[Thread.CurrentThread.ManagedThreadId].Enqueue(() => _set.Add(key, item));
            }
            else
            {
                _set.Add(key, item);
            }
		}

        public void Remove(K key)
        {
            Dictionary<K, V> shadowSet = null;
            if (_transactionShadowSets.TryGetValue(Thread.CurrentThread.ManagedThreadId, out shadowSet))
            {
                shadowSet.Remove(key);
                _transactionEventsLog[Thread.CurrentThread.ManagedThreadId].Enqueue(() => _set.Remove(key));
            }
            else
            {
                _set.Remove(key);
            }
        }

        public V Get(K key)
        {
            Dictionary<K, V> shadowSet = null;
            if (_transactionShadowSets.TryGetValue(Thread.CurrentThread.ManagedThreadId, out shadowSet))
            {
                V value;
                if (shadowSet.TryGetValue(key, out value))
                {
                    return value;
                }
                else
                {
                    throw new Exception("Key wasn't found");
                }
            }
            else
            {
                return _set[key];
            }
            
        }

        public void Rollback()
		{
            if (Monitor.TryEnter(syncRoot, new TimeSpan(0, 1, 0)))
            {
                try
                {
                    _transactionShadowSets.Remove(Thread.CurrentThread.ManagedThreadId);
                    _transactionEventsLog.Remove(Thread.CurrentThread.ManagedThreadId);
                }
                finally
                {
                    Monitor.Exit(syncRoot);
                }
            }
            
        }

		public void BeginTransaction()
		{
            if (Monitor.TryEnter(syncRoot, new TimeSpan(0, 1, 0)))
            {
                try
                {
                    _transactionShadowSets.Add(Thread.CurrentThread.ManagedThreadId, new Dictionary<K, V>());
                    _transactionEventsLog.Add(Thread.CurrentThread.ManagedThreadId, new Queue<Action>());
                }
                finally
                {
                    Monitor.Exit(syncRoot);
                }
            }
           
		}

		public void Commit()
        {
            var events = _transactionEventsLog[Thread.CurrentThread.ManagedThreadId];

            if (Monitor.TryEnter(syncRoot, new TimeSpan(0, 1, 0)))
            {
                try
                {
                    while (events.Count > 0)
                    {
                        events.Dequeue().Invoke();
                    }

                    _transactionShadowSets.Remove(Thread.CurrentThread.ManagedThreadId);
                    _transactionEventsLog.Remove(Thread.CurrentThread.ManagedThreadId);
                }
                finally
                {
                    Monitor.Exit(syncRoot);
                }
            }
            
        }

	}
}
