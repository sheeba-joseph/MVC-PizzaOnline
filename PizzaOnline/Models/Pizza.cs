using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOnline.Models
{
    public class Pizza
    {
        public int id { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Sauce { get; set; }
        public Dictionary<string, bool> Topping { get; set; }



    }
}