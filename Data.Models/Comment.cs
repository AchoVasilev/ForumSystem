namespace Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models.Base;

    public class Comment : BaseModel<int>
    {
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}