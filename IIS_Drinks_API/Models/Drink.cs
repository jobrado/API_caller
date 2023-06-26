using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS_Drinks_API.Models
{
    public class Drink
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Drink()
        {
        }

        public Drink(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return "Drink: " + Name + "! " + " Description of this drink: " + Description;
        }
    }
}