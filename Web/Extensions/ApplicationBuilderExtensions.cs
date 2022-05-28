namespace Web.Extensions
{
    using Data;
    using Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;
            var data = serviceProvider.GetRequiredService<ApplicationDbContext>();

            await SeedCategories(data);

            return app;
        }

        private static async Task SeedCategories(ApplicationDbContext data)
        {
            if(data.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "C#",
                    Description = "This category contains posts about the programming language C#",
                    Image = new Image()
                    {
                        Url = "https://softuni.bg/Content/images/university/professions/csharp.svg",
                        Extension = "svg",
                        Name = "csharp"
                    },
                },
                new Category()
                {
                    Name = "Dogs",
                    Description = "This category contains posts about dogs",
                    Image = new Image()
                    {
                        Url = "https://i.guim.co.uk/img/media/fe1e34da640c5c56ed16f76ce6f994fa9343d09d/0_174_3408_2046/master/3408.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=0d3f33fb6aa6e0154b7713a00454c83d",
                        Extension = "jpg",
                        Name = "3408"
                    },
                },
                new Category()
                {
                    Name = "Cats",
                    Description = "This category contains posts about cats",
                    Image = new Image()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cat_November_2010-1a.jpg/800px-Cat_November_2010-1a.jpg",
                        Extension = "jpg",
                        Name = "Cat_November_2010"
                    },
                },
                new Category()
                {
                    Name = "JavaScript",
                    Description = "This category contains posts about the programming language JavaScript",
                    Image = new Image()
                    {
                        Url = "https://flyclipart.com/thumb2/computer-icons-logo-brand-javascript-javaserver-pages-free-892749.png",
                        Extension = "png",
                        Name = "javascript"
                    },
                },
                new Category()
                {
                    Name = "Windows",
                    Description = "This category contains posts about Microsoft's Windows Operating system",
                    Image = new Image()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Windows_logo_-_2012.svg/2048px-Windows_logo_-_2012.svg.png",
                        Extension = "png",
                        Name = "Windows"
                    },
                },
                new Category()
                {
                    Name = "Linux",
                    Description = "This category contains posts about the Linux desktop environments",
                    Image = new Image()
                    {
                        Url = "https://upload.wikimedia.org/wikipedia/commons/d/dd/Linux_logo.jpg",
                        Extension = "jpg",
                        Name = "Linux"
                    },
                },
                new Category()
                {
                    Name = "Cars",
                    Description = "This category contains posts about cars",
                    Image = new Image()
                    {
                        Url = "https://images.squarespace-cdn.com/content/v1/51cdafc4e4b09eb676a64e68/1618602622635-4LFSCPXPMK8MOR64BC2N/cars_trip.jpg",
                        Extension = "jpg",
                        Name = "cars"
                    },
                },
                new Category()
                {
                    Name = "Sports",
                    Description = "This category contains posts about sports",
                    Image = new Image()
                    {
                        Url = "https://media.npr.org/assets/img/2020/06/10/gettyimages-200199027-001-b5fb3d8d8469ab744d9e97706fa67bc5c0e4fa40.jpg",
                        Extension = "jpg",
                        Name = "sports"
                    },
                },
            };

            await data.Categories.AddRangeAsync(categories);
            await data.SaveChangesAsync();
        }
    }
}