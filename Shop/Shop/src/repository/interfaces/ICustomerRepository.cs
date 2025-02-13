using Shop.model;

namespace Shop.repository.interfaces;

public interface ICustomerRepository
{
    Customer? getCustomerById(long id);

    Customer? getCustomerByName(string name);
    
    string? getAllCustomers();
    
    void addCustomer(Customer customer);
    
    void updateCustomer(Customer customer);
    
    void deleteCustomer(Customer customer);
    
}