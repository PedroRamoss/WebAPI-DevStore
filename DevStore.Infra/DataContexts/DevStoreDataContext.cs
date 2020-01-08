using DevStore.Domain.Model;
using DevStore.Infra.Mappings;
using System.Data.Entity;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext()
            : base("DevStoreConnectionString")
        {
            // Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informatica" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Products.Add(new Product { Id = 1, CategoryId = 1, IsActive = true, Title = "Notebook", Price = 1400.00m });
            context.Products.Add(new Product { Id = 2, CategoryId = 2, IsActive = true, Title = "Teclado Razer", Price = 200.00m });
            context.Products.Add(new Product { Id = 3, CategoryId = 2, IsActive = true, Title = "Mouse Razer", Price = 324.25m });
            context.Products.Add(new Product { Id = 4, CategoryId = 3, IsActive = true, Title = "Caneta Razer", Price = 01.25m });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
