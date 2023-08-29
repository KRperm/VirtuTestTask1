using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi
{
    public class DataContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseNpgsql(connectionString);
        }
    }
}
