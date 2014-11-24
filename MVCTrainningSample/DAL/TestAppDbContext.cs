using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCTrainningSample.Models.Mapping;
using MVCTrainningSample.Models;

namespace MVCTrainningSample.DAL
{
    public partial class TestAppDbContext : DbContext
    {
        static TestAppDbContext()
        {
            Database.SetInitializer<TestAppDbContext>(null);
        }

        public TestAppDbContext()
            : base("Name=TestAppDbContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductTypeMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
