using Shop.model;

namespace Shop.repository.interfaces;

public interface ISaleRepository
{
    Sale? getSaleById(long id);

    string? getSalesByCustomer(string customer);

    string? getSalesByProduct(string product);
    
    string? getAllSales();
    
    void addSale(Sale product);
    
    void updateSale(Sale product);
    
    void deleteSale(Sale product);
    
}