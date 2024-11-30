using EM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EM.API.Data
{
    public class EMDbContext : DbContext
    {
        public EMDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees{ get; set; }
    }
} 
