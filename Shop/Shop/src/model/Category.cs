using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("category_id")]
    public long category_id { get; set; }
    
    [Column("category_name")]
    public string category_name { get; set; }

    public Category(string category_name)
    {
        this.category_name = category_name;
    }

    public override string ToString() 
    {
        return "Name: " + category_name;
    }
}