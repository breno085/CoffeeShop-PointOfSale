using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.PointOfSale.EntityFramework.Models
{
    public class Order
    {
        public int OrderId { get; set;}
        public decimal TotalPrice { get; set;}
        public DateTime CreatedDate { get; set;}
        public ICollection<OrderProduct> OrderProducts { get; set;}

    }
}