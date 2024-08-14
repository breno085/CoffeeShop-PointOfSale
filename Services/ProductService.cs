using CoffeeShop.PointOfSale.EntityFramework.Services;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

public class ProductService
{
    internal static void InsertProduct()
    {
        Product product = new Product
        {
            Name = AnsiConsole.Ask<string>("Product's name: "),
            Price = AnsiConsole.Ask<decimal>("Product's price: "),
            CategoryId = CategoryService.GetCategoryOptionInput().CategoryId
        };
        ProductController.AddProduct(product);
    }
    static internal void DeleteProduct()
    {
        var product = GetProductOptionInput();

        ProductController.DeleteProduct(product);
    }

    internal static void GetProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update name? ") ? 
        AnsiConsole.Ask<string>("Product's new name: ")
        : product.Name;

        product.Price = AnsiConsole.Confirm("Update price? ") ? 
        AnsiConsole.Ask<decimal>("Product's new price: ")
        : product.Price;

        product.Category = AnsiConsole.Confirm("Update Category? ") ?
        CategoryService.GetCategoryOptionInput() : product.Category;

        ProductController.UpdateProduct(product);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    static private Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Product")
        .AddChoices(productsArray));

        var id = products.Single(x => x.Name == option).ProductId;
        var product = ProductController.GetProductById(id);

        return product;
    }
}