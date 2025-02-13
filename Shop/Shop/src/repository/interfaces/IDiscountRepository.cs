using Shop.model;

namespace Shop.repository.interfaces;

public interface IDiscountRepository
{
    Discount? getDiscountById(long id);
    
    string? getAllDiscounts();
    
    void addDiscount(Discount discount);
    
    void updateDiscount(Discount discount);
    
    void deleteDiscount(Discount discount);
    
}