using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Enums;

namespace task.Classes
{
  public class Product
  {
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public ProductCategory Category { get; private set; }

    public Product(string name, Money price, ProductCategory category)
    {
      Name = name;
      Price = price;
      Category = category;
    }

    public void ReducePrice(int amount)
    {
      int newWholePart = Price.WholePart - amount;
      if (newWholePart < 0) newWholePart = 0;
      Price = new Money(newWholePart, Price.Cents, Price.Currency);
    }

    public void Display()
    {
      Console.WriteLine($"Товар: {Name}, Категорія: {Category}, Ціна: {Price.WholePart}.{Price.Cents:D2} {Price.Currency.Symbol}");
    }
  }
}
