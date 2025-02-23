using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Classes
{
  public class Cart
  {
    private Dictionary<Product, int> _items = new Dictionary<Product, int>();

    public void AddToCart(Product product, int quantity)
    {
      if (_items.ContainsKey(product))
        _items[product] += quantity;
      else
        _items[product] = quantity;
    }

    public void RemoveFromCart(Product product, int quantity)
    {
      if (_items.ContainsKey(product))
      {
        _items[product] -= quantity;
        if (_items[product] <= 0) _items.Remove(product);
      }
    }

    public void DisplayCart()
    {
      Console.WriteLine("Вміст кошика:");
      foreach (var item in _items)
      {
        Console.WriteLine($"{item.Key.Name} - {item.Value} шт - {item.Key.Price.WholePart}.{item.Key.Price.Cents:D2} {item.Key.Price.Currency.Symbol}");
      }
    }
  }
}
