using CoffeeShop.PointOfSale.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale;

class Program
{
    static void Main(string[] args)
    {
        var context = new ProductContext();
        //OBS - only use EnsureDeleted and EnsureCreated if you are just testing and the database
        //doesnt already exists, so you don't have to delete the database
        //and created migrations everytime, but if there are already a working database 
        //and it is being used by real people dont use this
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        UserInterface.MainMenu();
    }
}
