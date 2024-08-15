using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }
    
    public List<Product> Products { get; set; } 
}