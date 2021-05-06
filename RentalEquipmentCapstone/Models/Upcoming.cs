using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models
{
    public class Upcoming
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public string Equipment
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        [Display(Name = "Image URL")]
        public string Image
        {
            get; set;
        }
    }
}
