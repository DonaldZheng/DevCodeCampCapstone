using RentalEquipmentCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.ViewModel
{
    public class ProductViewModel
    {
        public List<Product> _products
        {
            get; set;
        }
        public List<Product> findAll()
        {
            _products = new List<Product> { new Product()
                {
                    Id ="1", Name = "Flower1", Photo ="thumb1.jpg", Price = 100.00
                },
                new Product()
                {
                    Id ="2", Name = "Flower2", Photo ="thumb2.jpg", Price = 100.00
                },
                new Product()
                {
                    Id ="3", Name = "Flower3", Photo ="thumb3.jpg", Price = 100.00
                },
                new Product()
                {
                    Id ="4", Name = "Flower4", Photo ="thumb4.jpg", Price = 100.00
                },
                new Product()
                {
                    Id ="5", Name = "Flower5", Photo ="thumb5.jpg", Price = 100.00
                },

            };
            return _products;
        }
        public Product find(string id)
        {
            List<Product> products = findAll();
            var prod = products.Where(a => a.Id == id).FirstOrDefault();
            return prod;
        }

    }
}
