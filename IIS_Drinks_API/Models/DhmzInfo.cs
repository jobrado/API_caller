using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IIS_Drinks_API.Models
{
    public class DhmzInfo
    {
        [Display (Name ="City name:")]
        [Required(ErrorMessage = "City name is required!")]
        public string cityName;
        [Display(Name = "Temperature is:")]
        public string temperature;

        public DhmzInfo(string cityName, string temperature)
        {
            this.cityName = cityName;
            this.temperature = temperature;
        }
    }
}