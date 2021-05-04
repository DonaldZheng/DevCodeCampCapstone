using Microsoft.EntityFrameworkCore;
using RentalEquipmentCapstone.Models;
using RentalEquipmentCapstone.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Data.Repository
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _ctx;

        public Repository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public List<Post> GetAllPosts(int id)
        {
            return _ctx.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts
                 .Include(p => p.MainComments)
                 .ThenInclude(mc => mc.SubComments)
                 .FirstOrDefault(p => p.Id == id);
        }
        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }
        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
