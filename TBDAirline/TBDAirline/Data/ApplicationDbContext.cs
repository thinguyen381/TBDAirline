using Microsoft.EntityFrameworkCore;
using TBDAirline.Models;

namespace TBDAirline.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Airport> Airport { get; set; }


    }
}
