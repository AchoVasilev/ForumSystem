namespace Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models.Base;
    using static Constants.GlobalConstants;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(DataConstants.DefaultNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}