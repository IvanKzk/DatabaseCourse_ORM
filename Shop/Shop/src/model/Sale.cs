using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("sales")]
public class Sale
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("sale_id")]
    public long sale_id { get; set; }
    
    [Column("customer_id")]
    [ForeignKey("customer_id")]
    public long customer_id { get; set; }

    [Column("product_id")]
    [ForeignKey("product_id")]
    public long product_id { get; set; }
    
    [Column("quantity")]
    public int quantity { get; set; }

    [Column("sale_date")]
    public DateTime sale_date { get; set; }


    public Sale(long customer_id, long product_id, int quantity, DateTime sale_date)
    {
        this.customer_id = customer_id;
        this.product_id = product_id;
        this.quantity = quantity;
        this.sale_date = sale_date;
    }

    public override string ToString()
    {
        return "Customer: " + customer_id + "\nProduct: " + product_id + "\nQuantity: " + quantity + "\nDate: " + sale_date;
    }
}