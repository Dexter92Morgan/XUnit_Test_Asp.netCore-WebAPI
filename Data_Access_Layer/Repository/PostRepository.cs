using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.ViewModel;
using Data_Access_Layer.Interface;

namespace Data_Access_Layer.Repository
{
    public class PostRepository : IPostRepository
    {
        ApplicationDbContext db;

        public PostRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Category>> GetCategories()
        {
            if (db != null)
            {
                return await db.Categories.ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> GetPosts()
        {
            if (db != null)
            {
                return await (from p in db.Posts
                              from c in db.Categories
                              where p.CategoryId == c.Id
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if (db != null)
            {
                return await (from p in db.Posts
                              from c in db.Categories
                              where p.PostId == postId
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddPost(Post post)
        {
            if (db != null)
            {
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();

                return post.PostId;
            }

            return 0;
        }

        public async Task<int> DeletePost(int? postId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var post = await db.Posts.FirstOrDefaultAsync(x => x.PostId == postId);

                if (post != null)
                {
                    //Delete that post
                    db.Posts.Remove(post);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdatePost(Post post)
        {
            if (db != null)
            {
                //Delete that post
                db.Posts.Update(post);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


    }
}
