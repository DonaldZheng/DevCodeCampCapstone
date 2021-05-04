using RentalEquipmentCapstone.Models;
using RentalEquipmentCapstone.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts(int id);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        void AddSubComment(SubComment comment);

        Task<bool>SaveChangesAsync();
    }
}
