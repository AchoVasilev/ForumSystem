namespace Services.Categories
{
    using ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<IndexCategoryViewModel>> GetIndexCategories();
    }
}