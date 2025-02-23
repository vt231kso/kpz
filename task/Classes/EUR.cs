using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Interfaces;

namespace task.Classes
{
  public class EUR : ICurrency
  {
    public string Symbol => "€";
    public string Name => "EUR";
  }
}
