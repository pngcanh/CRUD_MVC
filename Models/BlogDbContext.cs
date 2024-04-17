using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Models
{
    public class BlogDbContext : DbContext
    {


        public DbSet<ArticlesModel> articles { set; get; }
        public DbSet<AuthorsModle> authors { set; get; }
        public DbSet<CategoriesModel> categories { set; get; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            //
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}



