using Avalonia;
using System;
using Avalonia.Controls.ApplicationLifetimes;

namespace Class3
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        //[STAThread]
        public static void Main(string[] args)
        {
            // Executar Ex. 1

            Ex1.run();

            // Executar Ex. 2

            var app = BuildAvaloniaApp();
            app.StartWithClassicDesktopLifetime(args);
        }
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
