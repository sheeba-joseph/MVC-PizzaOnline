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
        [HttpGet]
        public ActionResult BuildYourPizza()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BuildYourPizza(Pizza pizza)
        {
            if (Session["cart"] == null)
            {
                List<Pizza> li = new List<Pizza>();

                li.Add(pizza);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;


            }
            else
            {
                List<Pizza> li = (List<Pizza>)Session["cart"];
                li.Add(pizza);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }

            return View();
        }


       



       


       
}

}