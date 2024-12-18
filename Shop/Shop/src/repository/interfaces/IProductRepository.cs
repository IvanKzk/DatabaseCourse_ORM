using Shop.model;

namespace Shop.repository.interfaces;

public interface IProductRepository
{
    Product? getProductById(long id);

    Product? getProductByName(string name);

    string? getProductsByDepartment(string department);

    string? getProductsByCategory(string category);
    
    string? getAllProducts();
    
    void addProduct(Product product);
    
    void updateProduct(Product product);
    
    void deleteProduct(Product product);
    
}