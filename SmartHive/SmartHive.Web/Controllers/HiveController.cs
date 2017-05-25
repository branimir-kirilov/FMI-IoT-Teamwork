using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHive.Web.Controllers
{
    public class HiveController : Controller
    {
        // GET: Hive
        public ActionResult Index()
        {
            return View();
        }
    }
}