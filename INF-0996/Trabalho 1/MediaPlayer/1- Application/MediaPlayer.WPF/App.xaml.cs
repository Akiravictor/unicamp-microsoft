using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MediaPlayer.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IServiceProvider serviceProvider;

		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton<MainWindow>();
		}

		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = serviceProvider.GetService<MainWindow>();

			_ = mainWindow ?? throw new NullReferenceException(nameof(mainWindow));

			mainWindow.Show();
		}
	}
}
