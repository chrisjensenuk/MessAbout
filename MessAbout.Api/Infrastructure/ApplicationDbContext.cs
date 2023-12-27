using MessAbout.Api.Products;
using Microsoft.EntityFrameworkCore;

namespace MessAbout.Api.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
