using CoffeeShop.PointOfSale.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale;

class Program
{
    static void Main(string[] args)
    {
        var context = new ProductContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        UserInterface.MainMenu();
    }
}
