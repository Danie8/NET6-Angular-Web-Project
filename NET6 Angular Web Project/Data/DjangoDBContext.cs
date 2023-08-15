using Microsoft.EntityFrameworkCore;
using NET6_Angular_Web_Project.Models;

namespace NET6_Angular_Web_Project.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
