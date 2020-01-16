using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Please enter your first name" )]
        [Display(Name = "First name")]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your last Address")]
        [Display(Name = "Street address")]
        [StringLength(100)]
        public string Address { get; set;}
        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your zipcode")]
        [StringLength(5, MinimumLength = 4)]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }


    }
}
