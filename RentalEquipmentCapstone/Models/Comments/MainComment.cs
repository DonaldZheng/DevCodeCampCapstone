using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Models.Comments
{
    public class MainComment : Comment
    {
        public List<SubComment> SubComments // list of sub comments 
        {
            get; set;
        }
    }
}
