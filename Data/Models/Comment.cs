using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comments.Data.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string CommentText { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
