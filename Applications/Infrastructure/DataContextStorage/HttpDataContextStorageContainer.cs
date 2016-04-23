using System.Web;

namespace Infrastructure.DataContextStorage
{
    public class HttpDataContextStorageContainer<T> : IDataContextStorageContainer<T> where T : class
    {
        private const string DataContextKey = "DataContext";
        
        public T GetDataContext()
        {
            T objectContext = null;
            if (DataContextKeyExists())
            {
                objectContext = (T)HttpContext.Current.Items[DataContextKey];
            }
            return objectContext;
        }

        public void Clear()
        {
            if (DataContextKeyExists())
            {
                HttpContext.Current.Items[DataContextKey] = null;
            }
        }

        public void Store(T objectContext)
        {
            if (DataContextKeyExists())
            {
                HttpContext.Current.Items[DataContextKey] = objectContext;
            }
            else
            {
                HttpContext.Current.Items.Add(DataContextKey, objectContext);
            }
        }

        private static bool DataContextKeyExists()
        {
            return HttpContext.Current.Items.Contains(DataContextKey);
        }

    }
}
