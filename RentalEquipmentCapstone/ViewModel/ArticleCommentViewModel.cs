using RentalEquipmentCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.ViewModel
{
    public class ArticleCommentViewModel
    {
        public string Title
        {
            get; set;
        }
        public List<ArticleComment> ListOfComments
        {
            get; set;
        }
        public string Comment
        {
            get; set;
        }
        public int ArticlesId
        {
            get; set;
        }
        public int Rating
        {
            get; set;
        }
    }
}
