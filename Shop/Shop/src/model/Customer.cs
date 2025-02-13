using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("customers")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("customer_id")]
    public long customer_id { get; set; }
    
    [Column("customer_name")]
    public string customer_name { get; set; }

    [Column("total_spent")]
    public decimal total_spent { get; set; }

    public Customer(string customer_name, decimal total_spent)
    {
        this.customer_name = customer_name;
        this.total_spent = total_spent;
    }

    public override string ToString()
    {
        return "Name: " + customer_name;
    }
}