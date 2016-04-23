using System.Diagnostics.CodeAnalysis;
using MegaMediaManager.Mvc.App_Start;
using MegaMediaManager.DAL;
namespace MegaMediaManager.Tests.Mvc
{
    [ExcludeFromCodeCoverage]
    public class PresentationTestBase
    {
        /// <summary>
        /// Initializes a new instance of the PresentationTestBase class.
        /// </summary>
        public PresentationTestBase()
        {
            AutoMapperConfig.Start();

            MegaMediaManagerContextInitializer.Init(true);
        }
    }
}
