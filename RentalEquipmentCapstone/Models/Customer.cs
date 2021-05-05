using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId
        {
            get; set;
        }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Input")]
        public string FirstName
        {
            get; set;
        }
        [Display(Name = "Last Name")]
        public string LastName
        {
            get; set;
        }
        [Display(Name = "Street Name")]
        public string StreetName
        {
            get; set;
        }

        [Display(Name = "City")]
        public string City
        {
            get; set;
        }
        [Display(Name = "State")]
        public string State
        {
            get; set;
        }
        [Display(Name = "Zip Code")]
        public string ZipCode
        {
            get; set;
        }
        [Display(Name = "Months of Rental?")]
        public string RentedMonths
        {
            get; set;
        }
        [Display(Name = "Return Date")]
        public DateTime? ReturnDate
        {
            get; set;
        }
        [Display(Name = "Balance Due")]
        public string BalanceDue
        {
            get; set;
        }
        [Display(Name = "Deposit")]
        public string Deposit
        {
            get; set;
        }

        [Display(Name = "Equipment Rental")]
        public string Equipment
        {
            get; set;
        }
        [Display(Name = "Any Concerns")]
        public string Comment
        {
            get; set;
        }
        [Display(Name = "Longitude")]
        public double Longitude
        {
            get; set;
        }
        [Display(Name = "Latitude")]
        public double Latitude
        {
            get; set;
        }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId
        {
            get; set;
        }
        public IdentityUser IdentityUser
        {
            get; set;
        }
    }
}
