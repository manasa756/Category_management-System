using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class applicationDbContext:DbContext
    {
        public applicationDbContext(DbContextOptions<applicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
