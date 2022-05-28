namespace ViewModels.Home
{
    using ViewModels.Category;
    using ViewModels.Post;

    public class IndexViewModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<IndexCategoryViewModel> Categories { get; init; }

        public IEnumerable<PostViewModel> Posts { get; init; }
    }
}