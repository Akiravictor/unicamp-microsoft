using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace Class3
{
  public class CalculatorUI
  {
    MainWindow window;
    public CalculatorUI(MainWindow w)
    {
      window = w;
    }

    public void SetDisplayText(string value)
    {
      window.GetTextBox().Text = value;
    }

    public void AddCallbackForButton(char c, Action callback)
    {
      window.AddCallback(c, callback);
    }
  }
}