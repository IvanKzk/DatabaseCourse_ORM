using Shop.config;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.repository;

public class DiscountRepository : IDiscountRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public DiscountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Discount? getDiscountById(long id)
    {
        return _context.Discounts.Find(id);
    }

    public string? getAllDiscounts()
    {
        return String.Join("\n\n", _context.Discounts.ToList());
    }

    public void addDiscount(Discount discount)
    {
        var found = _context.Discounts.FirstOrDefault(a => (a.discount_rate == discount.discount_rate) && (a.min_purchase_amount == discount.min_purchase_amount));
        if (found == null)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();   
        }
    }

    public void updateDiscount(Discount discount)
    {
        _context.Discounts.Update(discount);  
        _context.SaveChanges();
    }

    public void deleteDiscount(Discount discount)
    {
        _context.Discounts.Remove(discount);    
        _context.SaveChanges();
    }
    
}