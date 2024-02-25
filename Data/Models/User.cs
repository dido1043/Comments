using Microsoft.AspNetCore.Identity;

namespace Comments.Data.Models
{
    public class User : IdentityUser
    {
        IList<Comment> Comments { get; set; }
        = new List<Comment>();
    }
}
