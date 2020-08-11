using BankRUs.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankRUs
{
    class BankRUsContext : DbContext
    {
        // För att Entity FrameWork medveten om vår Customer-Modell
        // då behöver vi implimentera DbSet<>
        public DbSet<Customer> Customer { get; set; }

        // protected virtual
        // protected abstract
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BankRUs;Trusted_Connection=True");

        }
    }
}
