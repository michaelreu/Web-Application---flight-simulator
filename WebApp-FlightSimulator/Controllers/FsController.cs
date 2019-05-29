using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_FlightSimulator.Controllers
{
    public class FsController : Controller
    {
        // GET: Fs
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult display(string ip, int port)
        {
            return View();
        }
    }
}