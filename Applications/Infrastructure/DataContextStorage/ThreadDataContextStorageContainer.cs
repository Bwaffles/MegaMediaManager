using System;
using System.Threading;
using System.Collections.Generic;

namespace Infrastructure.DataContextStorage
{
    public class ThreadDataContextStorageContainer<T> : IDataContextStorageContainer<T> where T : class
    {
        private static readonly Dictionary<string, T> StoredContexts = new Dictionary<string, T>();

        public T GetDataContext()
        {
            T context = null;

            if (ThreadExists())
                context = (T)StoredContexts[GetThreadName()];
            return context;
        }

        public void Clear()
        {
            if (ThreadExists())
            {
                StoredContexts[GetThreadName()] = null;
            }
        }

        public void Store(T objectContext)
        {
            if (ThreadExists())
            {
                StoredContexts[GetThreadName()] = objectContext;
            }
            else
            {
                StoredContexts.Add(GetThreadName(), objectContext);
            }
        }

        private static string GetThreadName()
        {
            if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                Thread.CurrentThread.Name = Guid.NewGuid().ToString();
            }
            return Thread.CurrentThread.Name;
        }

        private static bool ThreadExists()
        {
            return StoredContexts.ContainsKey(GetThreadName());
        }

    }
}
