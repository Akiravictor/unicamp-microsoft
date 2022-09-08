using JewelCollector.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot
{
	public class Bag
	{
		public int TotalItems { get; set; }
		public int TotalValue { get; set; }

		public Bag()
		{
			TotalItems = 0;
			TotalValue = 0;
		}

		public void AddItem(int value)
		{
			TotalItems++;
			TotalValue += value;
		}

		public void PrintBag()
		{
			Console.WriteLine($"Bag total items: {TotalItems} | Bag total value: {TotalValue}");
		}
	}
}
