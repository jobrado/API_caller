using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace IIS_Drinks_API.Services
{
    public class XSDService
    {
        public static bool XSDValidate(string file)
        {
            bool flag = true;
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(null, "C:\\Users\\Jo\\Documents\\Svi_predmeti\\6. SESTI SEMESTAR\\IIS\\IIS_Drinks_API\\IIS_Drinks_API\\Assets\\drinks.xsd");
            XmlReader rd = XmlReader.Create(file);

           XDocument xmlDocument = XDocument.Load(rd);
            xmlDocument.Validate(sc, (sender, args) =>
            {
                flag = false;
                throw new Exception(args.Message);
            });

            return flag;
        }
    }
}