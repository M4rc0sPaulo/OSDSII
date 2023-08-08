using Microsoft.EntityFrameworkCore;
using OsDsII.api.Models;

namespace OsDsII.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        //Criando contexto:
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(customer => customer.Email)
                .IsUnique();
                //Criando indice e unicidade pelo Email VIA IsUnique.
        }
    }
}