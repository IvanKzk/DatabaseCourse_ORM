using Microsoft.EntityFrameworkCore;
using Shop.model;

namespace Shop.config;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        configureDepartments(modelBuilder);
        configureCategories(modelBuilder);
        configureProducts(modelBuilder);
        configureSales(modelBuilder);
        configureDiscounts(modelBuilder);
        configureCustomers(modelBuilder);
    }

    private void configureDepartments(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Department>()
            .ToTable("departments")
            .HasKey(a => a.department_id);
        
        modelBuilder.Entity<Department>()
            .Property(a => a.department_name)
            .IsRequired();
    }

    private void configureCategories(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Category>()
            .ToTable("categories")
            .HasKey(a => a.category_id);

        modelBuilder.Entity<Category>()
            .Property(a => a.category_name)
            .IsRequired(); 
    }

    private void configureProducts(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Product>()
            .ToTable("products")
            .HasKey(a => a.product_id);

        modelBuilder.Entity<Product>()
            .Property(a => a.product_name)
            .IsRequired(); 

        modelBuilder.Entity<Product>()
            .Property(a => a.price)
            .IsRequired(); 
        
        modelBuilder.Entity<Product>()
            .Property(a => a.stock)
            .IsRequired(); 



        modelBuilder.Entity<Product>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(a => a.category_id);
        
        modelBuilder.Entity<Product>()
            .HasOne<Department>()
            .WithMany()
            .HasForeignKey(a => a.department_id);
    }

    private void configureSales(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Sale>()
            .ToTable("sales")
            .HasKey(a => a.sale_id);

        modelBuilder.Entity<Sale>()
            .Property(a => a.quantity)
            .IsRequired(); 

        modelBuilder.Entity<Sale>()
            .Property(a => a.sale_date)
            .IsRequired();


        modelBuilder.Entity<Sale>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(a => a.customer_id);
        
        modelBuilder.Entity<Sale>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(a => a.product_id);
    }

    private void configureDiscounts(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Discount>()
            .ToTable("discounts")
            .HasKey(a => a.discount_id);

        modelBuilder.Entity<Discount>()
            .Property(a => a.discount_rate)
            .IsRequired(); 

        modelBuilder.Entity<Discount>()
            .Property(a => a.min_purchase_amount)
            .IsRequired();
    }

    private void configureCustomers(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Customer>()
            .ToTable("customers")
            .HasKey(a => a.customer_id);

        modelBuilder.Entity<Customer>()
            .Property(a => a.customer_name)
            .IsRequired(); 

        modelBuilder.Entity<Customer>()
            .Property(a => a.total_spent)
            .IsRequired();
    }
}