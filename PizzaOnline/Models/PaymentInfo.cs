using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaOnline.Models
{
    public class PaymentInfo
    {
        public int Id { get; set; }
       

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(25, ErrorMessage = "Name cannot contain more than 25 Characters")]
        public string NameOnCard { get; set; }

        [StringLength(16, ErrorMessage = "Card No. cannot contain more than 16 Characters", MinimumLength = 16)]
        [Required(ErrorMessage = "Please Enter Card Number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Month")]
        public int ExpirationMonth { get; set; }

        [Required(ErrorMessage = "Please Enter Year")]
        public int ExpirationYear { get; set; }

        [StringLength(4, ErrorMessage = "Card No. cannot contain more than 4 Characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter Security Code")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Please Enter Zip Code")]
        public string BillingZipCode { get; set; }



    }
}