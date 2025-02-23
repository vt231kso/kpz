using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Classes
{
  public class Warehouse
  {
    private List<WarehouseItem> _items = new List<WarehouseItem>();

    public void AddItem(WarehouseItem item)
    {
      _items.Add(item);
    }

    public bool ShipItem(string productName, int amount)
    {
      var item = _items.FirstOrDefault(i => i.Product.Name == productName);
      if (item == null) return false;
      return item.RemoveStock(amount);
    }

    public void InventoryReport()
    {
      Console.WriteLine("Звіт по складу:");
      foreach (var item in _items)
      {
        item.Display();
        Console.WriteLine("-------------------");
      }
    }
  }
}
