using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections;
using IIS_Drinks_API.Models;
using Newtonsoft.Json;
using CookComputing.XmlRpc;
using System.Security.Principal;
using System.IO;

namespace IIS_Drinks_API.Services
{
    public class APIService
    {
        public static async Task<IEnumerable<Drink>> GetSpirits()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://drinks-digital1.p.rapidapi.com/v1/spirits?limit=20"),
                Headers =
    {
        { "X-RapidAPI-Key", "d966f5b46dmsh01894d8d9f21b51p139d1ajsn1bb45b123b7c" },
        { "X-RapidAPI-Host", "drinks-digital1.p.rapidapi.com" },
    },
            };
            IList<Drink> drinks = new List<Drink>();
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    drinks = JsonConvert.DeserializeObject<List<Drink>>(body);
                }
            }
            return drinks;

        }


        public static async Task<IEnumerable<Drink>> GetSpirit(string name)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://drinks-digital1.p.rapidapi.com/v1/spirits/search?query=" + name + "&limit=20"),
                Headers =
    {
        { "X-RapidAPI-Key", "d966f5b46dmsh01894d8d9f21b51p139d1ajsn1bb45b123b7c" },
        { "X-RapidAPI-Host", "drinks-digital1.p.rapidapi.com" },
    },
            };
            List<Drink> drink = new List<Drink>();
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                drink = JsonConvert.DeserializeObject<List<Drink>>(body);

            }

            return drink;
        }
    }
}