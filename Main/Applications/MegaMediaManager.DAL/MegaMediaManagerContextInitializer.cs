using System.Data.Entity;

namespace MegaMediaManager.DAL
{
    public class MegaMediaManagerContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MegaMediaManagerContext>
    {
        public static void Init(bool dropDatabaseIfModelChanges)
        {
            if (dropDatabaseIfModelChanges)
            {
                Database.SetInitializer(new MyDropCreateDatabaseIfModelChanges());
                using (var db = MegaMediaManagerContext.Create())
                    db.Database.Initialize(false);
            }
            else
                Database.SetInitializer<MegaMediaManagerContext>(null);
        }
    }
}
