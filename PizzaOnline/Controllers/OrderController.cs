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


            if (Session["count"] == null)
                ViewBag.cart = 0;
            else
                ViewBag.cart = Session["count"];

            Pizza pizza = new Pizza
            {
                id = 0,
                Crust = "",
                Size = "",
                Sauce = "",
                Topping = new Dictionary<string, bool> { { "Premium Chicken", false }, { "Ham", false }, { "Beef", false }, { "Bacon", false }, { "Garlic", false }, { "Onion", false }, { "Olives", false }, { "Tomatoes", false }, { "Pineapple", false } }

            };
            return View(pizza);
        }


        [HttpPost]
        public ActionResult BuildYourPizza(Pizza pizza)
        {



            if (Session["cart"] == null)
            {
                List<Pizza> liPizza = new List<Pizza>();

                liPizza.Add(pizza);
                Session["cart"] = liPizza;
                ViewBag.cart = liPizza.Count();
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




        [HttpGet]
        public ActionResult CheckOutItems()
        {


            double totalPrice = 0;

            List<CheckOutItem> liItems = new List<Models.CheckOutItem>();


            if (Session["cart"] != null && Session["count"] != null)
            {
                if (Convert.ToInt32(Session["count"]) == 1)
                    ViewBag.Items = "1 Item";
                else
                    ViewBag.Items = Session["count"] + " Items";

                for (int i = 0; i < Convert.ToInt32(Session["count"]); i++)
                {
                    List<Pizza> liPizza = (List<Pizza>)Session["cart"];
                    CheckOutItem item = new CheckOutItem();
                    Pizza pizza = liPizza[i];

                    item.Details = pizza.Size + " Size pizza with " + pizza.Crust + " Crust," + pizza.Sauce + " and toppings " + getTopping(pizza);
                    item.Price = getPrice(pizza.Size);
                    liItems.Add(item);
                    totalPrice += item.Price;
                }

            }


            ViewBag.TotalPrice = totalPrice;
            Session["TotalPrice"] = totalPrice;
            return View(liItems);

        }


        private double getPrice(string pizzaSize)
        {
            double price = 0;
            if (pizzaSize == "Small")
                price = 5.00;
            else if (pizzaSize == "Medium")
                price = 6.50;
            else

                price = 7.75;

            return price;
        }

        private string getTopping(Pizza pizza)
        {
            string sTopping = "";

            if (pizza.Topping["Premium Chicken"])
            {
                sTopping += "Premium Chicken";
            }

            if (pizza.Topping["Ham"])
            {
                sTopping += ", Ham";
            }
            if (pizza.Topping["Beef"])
            {
                sTopping += ", Beef";
            }
            if (pizza.Topping["Bacon"])
            {
                sTopping += ", Bacon";
            }
            if (pizza.Topping["Garlic"])
            {
                sTopping += ", Garlic";
            }
            if (pizza.Topping["Onion"])
            {
                sTopping += ", Onion";
            }
            if (pizza.Topping["Olives"])
            {
                sTopping += ", Olives";
            }
            if (pizza.Topping["Tomatoes"])
            {
                sTopping += ", Tomatoes";
            }
            if (pizza.Topping["Pineapple"])
            {
                sTopping += ", Pineapple";
            }


            return sTopping;
        }

        [HttpGet]
        public ActionResult PaymentInfo()
        {
            if (Session["TotalPrice"] != null)
                ViewBag.TotalPrice = Convert.ToDouble(Session["TotalPrice"]);
            else
                ViewBag.totalPrice = 0;

           List <SelectListItem> expYear = new List<SelectListItem>() {
                                                                        new SelectListItem {Text = "Year", Value = "0"},

                                                                      };
            int curYear = System.DateTime.Today.Year;
            for (int i = 0; i <= 20; i++)
            {

                expYear.Add(new SelectListItem { Text = Convert.ToString(curYear + i), Value = Convert.ToString(curYear + i) });
            }

            ViewBag.expYear = expYear;
            return View();
        }


        [HttpPost]
        public ActionResult PaymentInfo(PaymentInfo paymentInfo)
        {

            return View();
        }
    }

}