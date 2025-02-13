namespace Shop.dto;

public class SaleDto
{
    public string customer_name {get; set;}
    public string product_name {get; set;}
    public int quantity { get; set; }
    public DateTime sale_date { get; set; }
}