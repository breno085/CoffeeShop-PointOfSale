
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework
{
    public class ProductController
    {
        internal static void AddProduct(Product product)
        {
            //You need to declare using the "using" statment because
            //context is an umanageble resource and we need to dispose off
            //that is what the "using does"
            using var db = new ProductContext();
            db.Add(product);
            db.SaveChanges();
        }

        internal static void DeleteProduct(Product product)
        {
            using var db = new ProductContext();

            db.Remove(product);
            db.SaveChanges();
        }
        internal static Product GetProductById(int id)
        {
            using var db = new ProductContext();
            var product = db.Products
            .Include(x => x.Category)
            .SingleOrDefault(x => x.ProductId == id);

            return product;
        }

        internal static List<Product> GetProducts()
        {
            using var db = new ProductContext();

            var products = db.Products
            .Include(x => x.Category)
            .ToList();

            return products;
        }

        internal static void UpdateProduct(Product product)
        {
            using var db = new ProductContext();

            db.Update(product);
            
            db.SaveChanges();
        }
    }
}