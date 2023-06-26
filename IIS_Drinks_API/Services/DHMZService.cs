using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Services;
using CookComputing.XmlRpc;
using System.Xml;

namespace IIS_Drinks_API.Services
{
    public class DHMZService : XmlRpcService
    {
        [XmlRpcMethod("temperature.get")]
        public string GetTemperature(string cityName)
        {
            string url = $"https://vrijeme.hr/hrvatska_n.xml";
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage= client.GetAsync(url).Result;
            string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            string temperature = "";
            if (!string.IsNullOrEmpty(result))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Grad");
                foreach (XmlNode node in nodeList)
                {
                    if(node.SelectSingleNode("GradIme").InnerText.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                    {
                        string proba = node.FirstChild.LastChild.InnerText;
                        temperature = node.SelectSingleNode("Podatci").SelectSingleNode("Temp").InnerText;
                        break;
                    }
                }
            }

            return temperature;
        }
    }
    [WebService(Namespace = "IIS_Drinks_API.Services")]
    [XmlRpcService(Name = "DHMZ")]
    public class DHMZServer : XmlRpcService
    {
        [WebMethod(Description = "Dohvati temperaturu za grad")]
        public static string GetTemperature(string cityName)
        {
            DHMZService dhmzService = new DHMZService();
            return dhmzService.GetTemperature(cityName);
        }
    }
}