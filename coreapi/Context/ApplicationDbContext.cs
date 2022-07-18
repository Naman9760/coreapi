using coreapi.Model;
using Microsoft.EntityFrameworkCore;

namespace coreapi.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
    }
}
