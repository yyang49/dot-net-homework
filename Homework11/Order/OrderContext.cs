using System;
using System.Data.Entity;
using System.Linq;
using MySql.Data.EntityFramework;

namespace Order
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderContext : DbContext
    {
        public OrderContext(): base("OrderDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}