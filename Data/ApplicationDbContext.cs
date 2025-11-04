using Microsoft.EntityFrameworkCore;
using MiniBlog.Models;

namespace MiniBlog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options){}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostTag>()
                .HasKey(p=> new{p.PostId,p.TagId});

            modelBuilder.Entity<PostTag>()
                .HasOne(p=>p.Post)
                .WithMany(p=>p.PostTags)
                .HasForeignKey(p=>p.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>()
                .HasOne(p => p.Tag)
                .WithMany(p => p.PostTags)
                .HasForeignKey(p => p.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(p=>p.Post)
                .WithMany(p=>p.Comments)
                .HasForeignKey(p=>p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.PostId);

            modelBuilder.Entity<PostTag>()
                .HasIndex(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasIndex(pt => pt.TagId);
          
            modelBuilder.Entity<Post>()
                .HasIndex(p => p.CreatedAt);
        }

    }
}
