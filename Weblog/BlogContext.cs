using Microsoft.EntityFrameworkCore;
using Weblog.Mapping;
using Weblog.Model;

namespace Weblog
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        { 
        
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogMapping());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
