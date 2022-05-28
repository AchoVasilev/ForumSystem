namespace Services.Categories
{
    using Data;
    using ViewModels.Category;
    using Microsoft.EntityFrameworkCore;
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;

        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<IndexCategoryViewModel>> GetIndexCategories()
        {
            var result = await this.data.Categories
                .Where(x => x.IsDeleted == false)
                .Select(x => new IndexCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return result;
        }
    }
}