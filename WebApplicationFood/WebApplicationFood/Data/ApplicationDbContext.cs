using Microsoft.EntityFrameworkCore;
using WebApplicationFood.Models.Entities;

namespace WebApplicationFood.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }

    }
}
