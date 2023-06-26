using IIS_Drinks_API.Models;
using IIS_Drinks_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IIS_Drinks_API.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
      
        public async Task<ActionResult> GetSpirits() {
         IEnumerable<Drink> drinks = await APIService.GetSpirits();
         return View(drinks);
        }

        public ActionResult GetSpirit()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetSpirit(string name)
        {
           IEnumerable<Drink> drink = await APIService.GetSpirit(name);
           ViewBag.Drink = drink.FirstOrDefault();   
            
           return View();
        }
    }
}