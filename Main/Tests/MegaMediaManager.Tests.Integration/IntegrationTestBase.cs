using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using MegaMediaManager.DAL;
using MySql.Data.MySqlClient;

namespace MegaMediaManager.Tests.Integration
{
    [ExcludeFromCodeCoverage]
    public class IntegrationTestBase
    {
        internal IntegrationTestBase()
        {
            // Use LocalDB for Entity Framework by default
           // Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=(localdb)\\v11.0; Integrated Security=True; MultipleActiveResultSets=True");
            
            MegaMediaManagerContextInitializer.Init(true);
        }
    }
}

