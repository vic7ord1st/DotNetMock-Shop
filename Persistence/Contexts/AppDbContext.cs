
using Microsoft.EntityFrameworkCore;
using supermarket.API.Domain.Models;

namespace supermarket.API.Persistence.Contexts {

    public class AppDbContext: DbContext {
        
        public DbSet <User> users {get; set;}
        public DbSet <Category> categories {get; set;}
        public DbSet <Cart> carts {get; set;}
        public DbSet <Product> products {get; set;}

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options){}

        protected override void OnModelCreating (ModelBuilder builder){
            base.OnModelCreating(builder);

            // User Context
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.id);
            builder.Entity<User>().Property(u => u.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.firstName).IsRequired();
            builder.Entity<User>().Property(u => u.lastName).IsRequired();
            builder.Entity<User>().Property(u => u.password).IsRequired();
            builder.Entity<User>().Property(u => u.isAdmin).IsRequired();
            builder.Entity<User>().Property(u => u.email).IsRequired();
            builder.Entity<User>().HasIndex(u => u.email).IsUnique(true);
            builder.Entity<User>().HasOne(c => c.cart).WithOne(u => u.user).HasForeignKey<Cart>(c => c.userId).OnDelete(DeleteBehavior.Cascade);

            //Seeding the User table
            builder.Entity<User>().HasData(
                    new User {id = 1, firstName = "Victor", lastName = "Okoroafor", email = "okoroafor.victor@gmail.com", password = "Admin123", isAdmin = true},
                    new User {id = 2, firstName = "David", lastName = "Blaine", email = "davidblaine@blaine.com", password = "test1234", isAdmin = false}
                    
            );

            // Cateogry Context
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(c => c.id);
            builder.Entity<Category>().Property( c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property( c => c.name).IsRequired();
            builder.Entity<Category>().HasIndex(c => c.name).IsUnique(true);
            builder.Entity<Category>().HasMany(p => p.products).WithOne(c => c.category).HasForeignKey(p => p.categoryId);
            
            // Seeding the Category table
            builder.Entity<Category>().HasData(
                new Category {id = 1, name = "Food and Drinks"},
                new Category {id = 2, name = "Home Decor"}
            );

            builder.Entity<Cart>().ToTable("Carts");
            builder.Entity<Cart>().HasKey(c => c.id);
            builder.Entity<Cart>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cart>().Property(u => u.userId).IsRequired();
            builder.Entity<Cart>().HasMany(c => c.products).WithOne().OnDelete(DeleteBehavior.Cascade);

            //Seeding the Cart table
            builder.Entity<Cart>().HasData(
                new Cart { id = 1, userId = 2}
            );

            // Product Context
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.id);
            builder.Entity<Product>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.name).IsRequired();
            builder.Entity<Product>().Property(p => p.description).IsRequired();
            builder.Entity<Product>().Property(p => p.price).IsRequired();
            builder.Entity<Product>().Property(p => p.imageUrl).IsRequired();
            builder.Entity<Product>().Property(p => p.inStock).IsRequired();
            builder.Entity<Product>().Property(p => p.categoryId).IsRequired();

            // Seeding the Product Table
            builder.Entity<Product>().HasData(
                new Product { id = 1, categoryId = 1, name = "Coke", description = "A very refreshing beverage", price = 120, imageUrl = "google.com", inStock = true},
                new Product { id = 2, categoryId = 1, name = "Fanta", description = "Sunny side of life", price = 150, imageUrl = "google.com", inStock = true}
            );

        }
    }
}