using Shop.config;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.repository;

public class SaleRepository : ISaleRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public SaleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Sale getSaleById(long id)
    {
        return _context.Sales.Find(id);
    }

    public string? getSalesByCustomer(string customer)
    {
        var foundCustomer = _context.Customers.FirstOrDefault(a => a.customer_name.Equals(customer));

        if (foundCustomer == null)
        {
            return "notFound";
        }

        var sales = _context.Sales.Where(a => a.customer_id == foundCustomer.customer_id).ToList();

        if (!sales.Any())
        {
            return "noContent";
        }

        return String.Join("\n\n", sales.ToList());
    }

    public string? getSalesByProduct(string product)
    {
        var foundProduct = _context.Products.FirstOrDefault(a => a.product_name.Equals(product));

        if (foundProduct == null)
        {
            return "notFound";
        }

        var sales = _context.Sales.Where(a => a.product_id == foundProduct.product_id).ToList();

        if (!sales.Any())
        {
            return "noContent";
        }

        return String.Join("\n\n", sales.ToList());
    }

    public string? getAllSales()
    {
        return String.Join("\n\n", _context.Sales.ToList());
    }

    public void addSale(Sale sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();   
    }

    public void updateSale(Sale sale)
    {
        _context.Sales.Update(sale);  
        _context.SaveChanges();
    }

    public void deleteSale(Sale sale)
    {
        _context.Sales.Remove(sale);    
        _context.SaveChanges();
    }
    
}