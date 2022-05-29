namespace Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Categories;
    using Services.Posts;
    using ViewModels.Post;
    using Web.Extensions;

    using static Constants.GlobalConstants.Messages;

    public class PostController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;

        public PostController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = new CreatePostInputModel()
            {
                Categories = await this.categoryService.GetIndexCategories()
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.GetIndexCategories();
                return this.View(model);
            }

            var id = await this.postService.CreateAsync(model, this.User.GetId());
            this.TempData["Message"] = SuccessfulPostCreation;

            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        public IActionResult ById(int id)
        {
            return this.View();
        }
    }
}