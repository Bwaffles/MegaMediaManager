using System.Web.Mvc;
using Infrastructure;

namespace MegaMediaManager.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public readonly IUnitOfWorkFactory UnitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the BaseController class.
        /// </summary>
        public BaseController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }
	}
}