using Infrastructure.DataContextStorage;

namespace MegaMediaManager.DAL
{
    public static class DataContextFactory
    {
        public static void Clear()
        {
            var dataContextStorageContainer = DataContextStorageFactory<MegaMediaManagerContext>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        public static MegaMediaManagerContext GetDataContext()
        {
            var dataContextStorageContainer =
                DataContextStorageFactory<MegaMediaManagerContext>.CreateStorageContainer();
            var context = dataContextStorageContainer.GetDataContext();
            if (context == null)
            {
                context = MegaMediaManagerContext.Create();
                dataContextStorageContainer.Store(context);
            }
            return context;
        }
    }
}
