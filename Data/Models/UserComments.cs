using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Data.Models
{
    public class UserComments
    {
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public Comment Comment { get; set; }
    }
}
