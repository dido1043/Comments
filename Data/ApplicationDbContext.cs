using Comments.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comments.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserComments>()
                .HasKey(x => new { x.UserId, x.CommentId});
            builder.Entity<User>()
                .Property(u => u.Email);

            base.OnModelCreating(builder);
        }
    }
}
