
namespace Services.Posts
{
    using ViewModels.Post;
    
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetPosts();

        Task<int> CreateAsync(CreatePostInputModel model, string userId);
    }
}