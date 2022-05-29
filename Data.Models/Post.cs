namespace Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models.Base;
    using static Constants.GlobalConstants;

    public class Post : BaseModel<int>
    {
        [Required]
        [MaxLength(DataConstants.DefaultNameMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}