using Shop.model;

namespace Shop.repository.interfaces;

public interface ICategoryRepository
{
    Category? getCategoryById(long id);

    Category? getCategoryByName(string name);
    
    string? getAllCategories();
    
    void addCategory(Category category);
    
    void updateCategory(Category category);
    
    void deleteCategory(Category category);
    
}