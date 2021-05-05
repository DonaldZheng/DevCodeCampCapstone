using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models
{
    public class Article
    {
        [Key]
        public int Id
        {
            get; set;
        }
        [Display(Name = "Customer Name or Anonymous")]
        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public bool Active
        {
            get; set;
        }
        public ICollection<ArticleComment> ArticlesComments
        {
            get; set;
        }

    }
}
