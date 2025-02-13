using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id")]
    public long product_id { get; set; }
    
    [Column("product_name")]
    public string product_name { get; set; }
    
    [Column("department_id")]
    [ForeignKey("department_id")]
    public long department_id { get; set; }

    [Column("category_id")]
    [ForeignKey("category_id")]
    public long category_id { get; set; }
    
    [Column("price")]
    public decimal price { get; set; }

    [Column("stock")]
    public int stock { get; set; }

    [Column("size")]
    public string size { get; set; }
    
    [Column("color")]
    public string color { get; set; }

    [Column("pattern")]
    public string pattern { get; set; }

    public Product(string product_name, long department_id, long category_id, decimal price, int stock, string size, string color, string pattern)
    {
        this.product_name = product_name;
        this.department_id = department_id;
        this.category_id = category_id;
        this.price = price;
        this.stock = stock;
        this.size = size;
        this.color = color;
        this.pattern = pattern;
    }

    public override string ToString()
    {
        return "Department: " + department_id + "\nCategory: " + category_id + "\nPrice: " + price + "\nStock: " + stock + "\nSize: " + size + "\nColor: " + color + "\nPattern: " + pattern;
    }
}