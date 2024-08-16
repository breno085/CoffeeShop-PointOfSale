using System.Globalization;
using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Models;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

public class ReportService
{
    internal static void CreateMonthlyReports()
    {
        var orders = OrderController.GetOrders();
        
        var reports = orders.GroupBy( x => new
        {
            x.CreatedDate.Month,
            x.CreatedDate.Year
        })
        .Select(grp => new MonthlyReportDTO
        {
            Month = $"{CultureInfo.CurrentCulture.DateTimeFormat
            .GetMonthName(grp.Key.Month)}/{grp.Key.Year}",
            TotalPrice = grp.Sum( grp => grp.TotalPrice),
            TotalQuantity = grp.Sum(x => x.OrderProducts.Sum
            (x => x.Quantity))
        }).ToList();

        UserInterface.ShowReportByMonth(reports);
    }
}