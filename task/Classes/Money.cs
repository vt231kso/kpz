using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Interfaces;

namespace task.Classes
{
  public class Money
  {
    public int WholePart { get; private set; }
    public int Cents { get; private set; }
    public ICurrency Currency { get; private set; }

    public Money(int wholePart, int cents, ICurrency currency)
    {
      if (wholePart < 0 || cents < 0) throw new ArgumentException("Invalid money values");
      WholePart = wholePart;
      Cents = cents;
      Currency = currency;
    }

    public void Display()
    {
      Console.WriteLine($"Сума: {WholePart}.{Cents:D2} {Currency.Symbol}");
    }
  }
}
