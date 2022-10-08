using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class2

{
	public class Ex1
	{
		public static void run()
		{
			// Imprima os números 1 - 1000 em uma thread, e os números 1001-2000 em
			// outra thread.
			// Use System.Threading.Thread.
			// Quando ambas as threads terminarem, imprima "Pronto.".

			var thread1 = new Thread(Write1000);
			var thread2 = new Thread(Write2000);

			thread1.Start();
			thread2.Start();
			thread1.Join();
			thread2.Join();

			Console.WriteLine("Ex1 Pronto");

		}

		public static void Write1000()
		{
			for (int i = 1; i < 1001; i++)
			{
				Console.WriteLine($"T1: {i}");
			}
		}

		public static void Write2000()
		{
			for (int i = 1001; i < 2001; i++)
			{
				Console.WriteLine($"T2: {i}");
			}
		}

	}
}