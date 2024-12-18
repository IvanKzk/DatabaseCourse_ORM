using Shop.config;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.repository;

public class ProductRepository : IProductRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Product? getProductById(long id)
    {
        return _context.Products.Find(id);
    }

    public Product? getProductByName(string name)
    {
        return _context.Products.FirstOrDefault(a => a.product_name.Equals(name));
    }

    public string? getProductsByDepartment(string department)
    {
        var foundDepartment = _context.Departments.FirstOrDefault(a => a.department_name.Equals(department));

        if (foundDepartment == null)
        {
            return "notFound";
        }

        var products = _context.Products.Where(a => a.department_id == foundDepartment.department_id).ToList();

        if (!products.Any())
        {
            return "noContent";
        }

        return String.Join("\n\n", products.ToList());
    }

    public string? getProductsByCategory(string category)
    {
        var foundCategory = _context.Categories.FirstOrDefault(a => a.category_name.Equals(category));

        if (foundCategory == null)
        {
            return "notFound";
        }

        var products = _context.Products.Where(a => a.category_id == foundCategory.category_id).ToList();

        if (!products.Any())
        {
            return "noContent";
        }

        return String.Join("\n\n", products.ToList());
    }

    public string? getAllProducts()
    {
        return String.Join("\n\n", _context.Products.ToList());
    }

    public void addProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();   
    }

    public void updateProduct(Product product)
    {
        _context.Products.Update(product);  
        _context.SaveChanges();
    }

    public void deleteProduct(Product product)
    {
        _context.Products.Remove(product);    
        _context.SaveChanges();
    }
    
}