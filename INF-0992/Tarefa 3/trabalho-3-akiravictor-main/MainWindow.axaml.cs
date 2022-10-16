using System;
using Avalonia.Controls;
using System.Collections.Generic;

namespace Class3
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      Width = 300;
      Height = 300;

      GetTextBox().TextAlignment = Avalonia.Media.TextAlignment.Right;
      GetTextBox().Text = "0";
      GetTextBox().IsEnabled = false;

    }

    public TextBox GetTextBox()
    {
#pragma warning disable
      return (LogicalChildren[0]! as StackPanel).Children[0]! as TextBox;
#pragma warning enable
    }
    Button GetButton(char c)
    {
      var positions = new List<string>{
        "π↶↷C",
        "789+",
        "456-",
        "123*",
        "0.=/"
      };

      for (int row = 0; row < 5; row++)
      {
        for (int col = 0; col < 4; col++)
        {
          if (positions[row][col] == c)
          {
#pragma warning disable
            var btn = ((LogicalChildren[0]! as StackPanel).Children[row + 1] as StackPanel).Children[col]! as Button;
#pragma warning enable;
            return btn;
          }
        }
      }
      throw new Exception(String.Format("char '{0}' not a button!", c));
    }
    public void AddCallback(char c, Action callback)
    {
      if (GetButton(c) is Button btn)
      {
        btn.Click += new EventHandler<Avalonia.Interactivity.RoutedEventArgs>((obj, args) => { callback(); });
      }
    }

  }

}