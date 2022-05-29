namespace ViewModels.Post
{
    using System.ComponentModel.DataAnnotations;
    using ViewModels.Category;
    using static Constants.GlobalConstants;

    public class CreatePostInputModel
    {
        [Required]
        [StringLength(DataConstants.DefaultNameMaxLength, MinimumLength = DataConstants.DefaultNameMinLength)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<IndexCategoryViewModel>? Categories { get; set; }
    }
}