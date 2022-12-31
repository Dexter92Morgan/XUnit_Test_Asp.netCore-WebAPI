using Data_Access_Layer.Models;
using Data_Access_Layer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interface
{
    public interface IPostRepository
    {
        Task<List<Category>> GetCategories();

        Task<List<PostViewModel>> GetPosts();

        Task<PostViewModel> GetPost(int? postId);

        Task<int> AddPost(Post post);

        Task<int> DeletePost(int? postId);

        Task UpdatePost(Post post);
    }
}
