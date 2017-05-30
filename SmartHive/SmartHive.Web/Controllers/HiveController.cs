using System.Web.Mvc;

namespace SmartHive.Web.Controllers
{
    [Authorize]
    public class HiveController : Controller
    {
        // GET: Hive
        public ActionResult Index()
        {
            return View();
        }
    }
}