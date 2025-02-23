using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Classes
{
  public class Reporting
  {
    private List<string> _incomeReports = new List<string>();
    private List<string> _shipmentReports = new List<string>();

    public void RegisterIncome(WarehouseItem item)
    {
      _incomeReports.Add($"Надходження: {item.Quantity} {item.Unit} {item.Product.Name} за ціною {item.Product.Price.WholePart}.{item.Product.Price.Cents:D2} {item.Product.Price.Currency.Symbol}");
    }

    public void RegisterShipment(WarehouseItem item, int amount)
    {
      _shipmentReports.Add($"Відвантаження: {amount} {item.Unit} {item.Product.Name}");
    }

    public void ShowReports()
    {
      Console.WriteLine("Звіти:");
      Console.WriteLine("=== Прибуткові накладні ===");
      foreach (var report in _incomeReports) Console.WriteLine(report);

      Console.WriteLine("=== Видаткові накладні ===");
      foreach (var report in _shipmentReports) Console.WriteLine(report);
    }
  }
}
