using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Classes
{
  public class WarehouseItem
  {
    public Product Product { get; private set; }
    public string Unit { get; private set; } // шт, кг, л
    public int Quantity { get; private set; }
    public DateTime LastRestockDate { get; private set; }

    public WarehouseItem(Product product, string unit, int quantity, DateTime lastRestockDate)
    {
      Product = product ?? throw new ArgumentNullException(nameof(product));
      Unit = unit ?? throw new ArgumentNullException(nameof(unit));
      Quantity = quantity >= 0 ? quantity : throw new ArgumentException("Кількість не може бути від'ємною");
      LastRestockDate = lastRestockDate;
    }

    public void AddStock(int amount)
    {
      if (amount <= 0) throw new ArgumentException("Кількість для додавання повинна бути позитивною");
      Quantity += amount;
      LastRestockDate = DateTime.Now;
    }

    public bool RemoveStock(int amount)
    {
      if (amount <= 0) throw new ArgumentException("Кількість для віднімання повинна бути позитивною");
      if (amount > Quantity) return false;
      Quantity -= amount;
      return true;
    }

    public void Display()
    {
      Console.WriteLine($"Товар: {Product.Name}, Категорія: {Product.Category}, Ціна: {Product.Price.WholePart}.{Product.Price.Cents:D2} {Product.Price.Currency.Symbol}");
      Console.WriteLine($"Одиниця виміру: {Unit}, Кількість: {Quantity}, Останнє постачання: {LastRestockDate}");
    }
  }
}
