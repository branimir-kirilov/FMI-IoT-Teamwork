using SmartHive.Services.Contracts;
using System;
using System.Web.Mvc;

namespace SmartHive.Web.Controllers
{
    [Authorize]
    public class HiveController : Controller
    {
        private readonly IHiveService hiveService;
        public HiveController(IHiveService hiveService)
        {
            if(hiveService == null)
            {
                throw new ArgumentNullException(nameof(hiveService));
            }

            this.hiveService = hiveService;
        }
        // GET: Hive
        public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        {
            return View("index", await hiveService.GetHiveAsync());
        }
    }
}