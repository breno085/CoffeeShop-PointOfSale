using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.Models;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }
    
    public List<Product> Products { get; set; } 
    
}