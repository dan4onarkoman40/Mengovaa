using mengova.Models;
using Microsoft.EntityFrameworkCore;

namespace mengova.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet <Category> mengova { get; set; }
    }
}
