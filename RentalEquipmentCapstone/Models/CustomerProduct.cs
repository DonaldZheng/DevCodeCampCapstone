using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models
{
    public class CustomerProduct
    {
        [ForeignKey("Customer")]
        public int CustomerId
        {
            get; set;
        }
        public Customer Customer
        {
            get; set;
        }

        [ForeignKey("Product")]
        public int ProductId
        {
            get; set;
        }
        public Product Product
        {
            get; set;
        }
    }
}
