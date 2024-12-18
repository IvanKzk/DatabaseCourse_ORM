using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.model;

[Table("departments")]
public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("department_id")]
    public long department_id { get; set; }
    
    [Column("department_name")]
    public string department_name { get; set; }

    public Department(string department_name)
    {
        this.department_name = department_name;
    }

    public override string ToString()
    {
        return "Name: " + department_name;
    }
}