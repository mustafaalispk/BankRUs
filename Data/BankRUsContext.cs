using BankRUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BankRUs
{
    class BankRUsContext : DbContext
    {
        // För att Entity FrameWork medveten om vår Customer-Modell
        // då behöver vi implimentera DbSet<>
        public DbSet<Customer> Customer { get; set; }
        public ILoggerFactory Factory { get; }

        public BankRUsContext(ILoggerFactory factory)
        {
            Factory = factory;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(Factory);

            optionsBuilder.UseSqlServer("Server=.;Database=BankRUs;Trusted_Connection=True");

        }
    }
}
