namespace Services.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext data;

        public PostService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<PostViewModel>> GetPosts()
        {
            var result = await this.data.Posts
                .Where(x => x.IsDeleted == false)
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    UserUserName = x.User.UserName
                })
                .ToListAsync();

            return result;
        }
    }
}