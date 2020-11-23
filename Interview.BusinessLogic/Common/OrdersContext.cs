using Microsoft.EntityFrameworkCore;

namespace Interview.BusinessLogic.Common
{
    public class OrdersContext : DbContext
    {
        private readonly string _connectionString;

        public OrdersContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(Customers.Infrastructure.CustomerMap.GetInstance());
            modelBuilder.ApplyConfiguration(Products.Infrastructure.ProductMap.GetInstance());
        }

    }
}
