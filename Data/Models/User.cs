using Microsoft.AspNetCore.Identity;

namespace Comments.Data.Models
{
    public class User : IdentityUser
    {
        IList<UserLoginInfo> Logins { get; set; }
    }
}
