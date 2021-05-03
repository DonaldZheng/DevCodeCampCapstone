﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models
{
    public class Product
    {
        [Key]
        public int ProductId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public ICollection<CustomerProduct> ShoppingCart
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