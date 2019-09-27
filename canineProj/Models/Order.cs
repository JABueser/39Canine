using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a Zip Code")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter the name associated with the credit card")]
        public string CreditName { get; set; }
        [Required(ErrorMessage = "Please enter a credit card Number")]
        public int CreditCard { get; set; }
        [Required(ErrorMessage = "Please enter an expiration date")]
        public int ExpDate { get; set; }
        [Required(ErrorMessage = "Please enter a security code associated with your credit card")]
        public int CIV { get; set; }
        public bool GiftWrap { get; set; }
    }
}
