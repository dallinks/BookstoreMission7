using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore2.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int DonationId { get; set; }
        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please enter an city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter an state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter an zip code")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter an zip code")]
        public string Country { get; set; }
        [Required(ErrorMessage ="Please enter phone number")]
        [Phone]
        public string PhoneNumber { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
    }
}
