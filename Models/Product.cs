using System.ComponentModel.DataAnnotations.Schema;

namespace Quanta.Models;

public class Product
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("product_code")]
    public string ProductCode { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("category")]
    public string Category { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }
}