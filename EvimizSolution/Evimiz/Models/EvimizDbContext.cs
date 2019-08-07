using Evimiz.Migrations;
using Evimiz.Models.Entity;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Evimiz.Models.Entity
{
    public class EvimizDbContext : DbContext
    {
        public EvimizDbContext()
              : base("name=cString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EvimizDbContext, Migrations.Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Add(new AttributeToColumnAnnotationConvention<EvimizDatabaseGeneratedAttribute, string>("EvimizDatabaseGeneratedAttribute", (p, attr) => attr.Single().DefaultValueSql));


            base.OnModelCreating(builder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SubCategory> Subcategory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}