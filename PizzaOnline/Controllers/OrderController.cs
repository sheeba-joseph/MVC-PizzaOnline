using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaOnline.Models;

namespace PizzaOnline.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult BuildYourPizza()
        {
            return View();
        }
    }
}