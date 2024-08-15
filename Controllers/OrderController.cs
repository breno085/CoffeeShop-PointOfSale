using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.PointOfSale.EntityFramework.Models;
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
}