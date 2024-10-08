using Microsoft.EntityFrameworkCore;
using sprint_1.Models;

namespace sprint_1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<user> Users { get; set; }
    }
}
