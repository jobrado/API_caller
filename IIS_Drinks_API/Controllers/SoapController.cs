using IIS_Drinks_API.Models;
using System.ServiceModel;
using System;
using System.Web.Mvc;
using System.Xml.Linq;

using Newtonsoft.Json.Linq;
using System.Web.Services.Protocols;

namespace IIS_Drinks_API.Controllers
{
    public class SoapController : Controller
    {
        public ActionResult GetDrink()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetDrink(string value)
        {
            try
            {
                
                soapservice.GetDataSoapClient getDataSoapClient = new soapservice.GetDataSoapClient();
                soapservice.Drink drink = getDataSoapClient.GetDrink(value);
                ViewBag.Drink = drink;
            }
            catch (FaultException ex)
            {
                Console.WriteLine($"SOAP fault: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return View();

        }
    }
}