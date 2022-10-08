using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class2

{
	public class Ex2
	{
		public static void run()
		{
			// Imprima os números 1 - 1000 em uma thread, e os números 1001-2000 em
			// outra thread.
			// Use System.Threading.Task.
			// Quando ambas as threads terminarem, imprima "Pronto.".

			var task1 = Task.Run(() => {
				for (int i = 1; i < 1001; i++)
				{
					Console.WriteLine($"Task1: {i}");
				}
			});

			var task2 = Task.Run(() =>
			{
				for(int i = 1001; i < 2001; i++)
				{
					Console.WriteLine($"Task2: {i}");
				}
			});

			task1.Wait();
			task2.Wait();

			Console.WriteLine("Ex2 Pronto");
		}
	}
}
