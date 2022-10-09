using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Class3
{
  public partial class App : Application
  {

    CalculatorUI? UI;

    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {


      base.OnFrameworkInitializationCompleted();

      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        desktop.MainWindow = new MainWindow();
        UI = new CalculatorUI((desktop.MainWindow as MainWindow)!);
        Ex2.run(UI);

      }

    }
  }
}