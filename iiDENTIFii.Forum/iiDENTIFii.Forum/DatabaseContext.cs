using iiDENTIFii.Forum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iiDENTIFii.Forum
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("getdate()");
            base.OnModelCreating(builder);
        }
    }
}