using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("discounts")]
public class Discount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("discount_id")]
    public long discount_id { get; set; }
    
    [Column("discount_rate")]
    public decimal discount_rate { get; set; }

    [Column("min_purchase_amount")]
    public decimal min_purchase_amount { get; set; }

    public Discount(decimal discount_rate, decimal min_purchase_amount)
    {
        this.discount_rate = discount_rate;
        this.min_purchase_amount = min_purchase_amount;
    }

    public override string ToString()
    {
        return "Rate: " + discount_rate + "\nMin. purchase amount: " + min_purchase_amount;
    }
}