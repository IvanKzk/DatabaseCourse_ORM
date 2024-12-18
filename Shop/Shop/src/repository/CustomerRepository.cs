using Shop.config;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.repository;

public class CustomerRepository : ICustomerRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Customer? getCustomerById(long id)
    {
        return _context.Customers.Find(id);
    }

    public Customer? getCustomerByName(string name)
    {
        return _context.Customers.FirstOrDefault(a => a.customer_name == name);
    }

    public string? getAllCustomers()
    {
        return String.Join("\n\n", _context.Customers.ToList());
    }

    public void addCustomer(Customer customer)
    {
        var found = _context.Customers.FirstOrDefault(a => a.customer_name == customer.customer_name);
        if (found == null)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();   
        }
    }

    public void updateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);  
        _context.SaveChanges();
    }

    public void deleteCustomer(Customer customer)
    {
        _context.Customers.Remove(customer);    
        _context.SaveChanges();
    }
    
}