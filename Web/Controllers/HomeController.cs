namespace Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Services.Categories;
    using Services.Posts;
    using ViewModels.Home;
    using Web.Models;

    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;

        public HomeController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel()
            {
                Categories = await this.categoryService.GetIndexCategories(),
                Posts = await this.postService.GetPosts()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}