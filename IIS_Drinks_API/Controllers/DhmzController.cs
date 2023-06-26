using IIS_Drinks_API.Models;
using IIS_Drinks_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIS_Drinks_API.Controllers
{
    public class DhmzController : Controller
    {
        // GET: Dhmz
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string cityName)
        {
            DhmzInfo dhmzInfo = new DhmzInfo(cityName, DHMZServer.GetTemperature(cityName));
            ViewBag.Dhmz = dhmzInfo;
            return View(dhmzInfo);
        }
    }
}