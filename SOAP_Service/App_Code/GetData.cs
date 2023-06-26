using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
/// <summary>
/// Summary description for GetData
/// </summary>
[WebService(Namespace = "soapservice")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GetData : System.Web.Services.WebService
{

    public GetData()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public IIS_Drinks_API.Models.Drink GetDrink(string val)
    {
        string body;
        List<IIS_Drinks_API.Models.Drink> drinks = new List<IIS_Drinks_API.Models.Drink>();
        string path = @"C:\Users\Jo\Documents\Svi_predmeti\6. SESTI SEMESTAR\IIS\IIS_Drinks_API\SOAP_Service\App_Code\Drinks\drinks.xml";
        using (var webClient = new WebClient())
        {
            webClient.Headers.Add("X-RapidAPI-Key", "d966f5b46dmsh01894d8d9f21b51p139d1ajsn1bb45b123b7c");
            webClient.Headers.Add("X-RapidAPI-Host", "drinks-digital1.p.rapidapi.com");
            body = webClient.DownloadString("https://drinks-digital1.p.rapidapi.com/v1/spirits?limit=20");
            drinks = JsonConvert.DeserializeObject<List<IIS_Drinks_API.Models.Drink>>(body);
        }

      
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<IIS_Drinks_API.Models.Drink>));
            StreamWriter writer = new StreamWriter(path);
            xmlSerializer.Serialize(writer, drinks);

            Console.Write(writer.ToString());
            writer.Close();
        

        XmlDocument doc = new XmlDocument();
        XDocument xdoc = XDocument.Load(path);


        string xpath = $"//Drink[Id = '{val}']";
       

        XElement xElement = xdoc.XPathSelectElement(xpath);

        if (xElement == null)
        {
            return null;
        }
        else
        {

               string id =  xElement.Element("Id").Value;
               string name =xElement.Element("Name").Value;
               string description = xElement.Element("Description").Value;

              return new IIS_Drinks_API.Models.Drink(id, name, description);
            
        }
    }

}
