using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

public class OrderController
{
    internal static void AddOrder(List<OrderProduct> orders)
    {
        using var db = new ProductContext();

        db.OrderProducts.AddRange(orders);

        db.SaveChanges();
    }

    internal static List<Order> GetOrders()
    {
        using var db = new ProductContext();

        var ordersList = db.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ThenInclude(p => p.Category)
            .ToList();

        return ordersList;
    }
}