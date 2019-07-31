using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Gympass.Repository
{
    public class GympassContext : DbContext
    {
        public GympassContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Lap> Laps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().Build();

                var connection = @"Server=(localdb)\mssqllocaldb;Database=Gympass;Trusted_Connection=True;ConnectRetryCount=0";

                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}
