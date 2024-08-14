using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

public class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductContext();

        db.Add(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ProductContext();

        db.Remove(category);

        db.SaveChanges();
    }


    internal static void UpdateCategory(Category category)
    {
        using var db = new ProductContext();

        db.Update(category);

        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ProductContext();

        var categories = db.Categories
        .Include(x => x.Products)
        .ToList();

        return categories;
    }
}