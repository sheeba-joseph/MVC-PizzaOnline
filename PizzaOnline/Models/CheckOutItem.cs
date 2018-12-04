using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaOnline.Models
{
    public class CheckOutItem
    {
        public int id { get; set; }
        public string  Details { get; set; }
        [UIHint("Currency")]
        public double Price { get; set; }
    }
}