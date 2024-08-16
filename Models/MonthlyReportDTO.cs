using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.PointOfSale.EntityFramework.Models
{
    public class MonthlyReportDTO
    {
        public string Month { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}