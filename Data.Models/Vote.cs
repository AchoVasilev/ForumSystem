
namespace Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.Models.Base;
    using Data.Models.Enums;

    public class Vote : BaseModel<int>
    {
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType VoteType { get; set; }
    }
}