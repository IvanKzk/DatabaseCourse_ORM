using Shop.config;
using Shop.model;

using Shop.repository.interfaces;
namespace Shop.repository;

public class CategoryRepository : ICategoryRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Category? getCategoryById(long id)
    {
        return _context.Categories.Find(id);
    }

    public Category? getCategoryByName(string name)
    {
        return _context.Categories.FirstOrDefault(a => a.category_name == name);
    }

    public string? getAllCategories()
    {
        return String.Join("\n\n", _context.Categories.ToList());
    }

    public void addCategory(Category category)
    {
        var found = _context.Categories.FirstOrDefault(a => a.category_name == category.category_name);
        if (found == null)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();   
        }
    }

    public void updateCategory(Category category)
    {
        _context.Categories.Update(category);  
        _context.SaveChanges();
    }

    public void deleteCategory(Category category)
    {
        _context.Categories.Remove(category);    
        _context.SaveChanges();
    }
    
}