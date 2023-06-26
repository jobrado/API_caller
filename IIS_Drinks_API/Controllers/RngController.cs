using IIS_Drinks_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace IIS_Drinks_API.Controllers
{
    public class RngController : Controller
    {
        // GET: Rng
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Assets"), _FileName);
                    file.SaveAs(_path);

                    if (Services.RNGService.RNGValidate(_path))
                    {
                        ViewBag.Message = "File Validated Successfully!!";

                        XmlDocument xmlDcoument = new XmlDocument();
                        xmlDcoument.Load(_path);
                        XmlNodeList xmlNodeList = xmlDcoument.DocumentElement.SelectNodes("/drinks/drink");
                        IList<Drink> drinks = new List<Drink>();
                        foreach (XmlNode xmlNode in xmlNodeList)
                        {
                            drinks.Add(new Drink(xmlNode.SelectSingleNode("id").InnerText, xmlNode.SelectSingleNode("name").InnerText, xmlNode.SelectSingleNode("description").InnerText));
                        }
                        return View(drinks);
                    }
                    else
                    {
                        ViewBag.Message = "File Not Validated Successfully!!";
                        return View();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}
