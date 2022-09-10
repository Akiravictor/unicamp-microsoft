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
		/// <summary>
		/// Stores the number of items collected.
		/// </summary>
		public int TotalItems { get; private set; }

		/// <summary>
		/// Stores the total value of items collected.
		/// </summary>
		public int TotalValue { get; private set; }

		/// <summary>
		/// Constructor for <typeparamref name="Bag" />.
		/// Initializes <paramref name="TotalItems" /> and <paramref name="TotalValue" />.
		/// </summary>
		public Bag()
		{
			TotalItems = 0;
			TotalValue = 0;
		}

		/// <summary>
		/// Adds 1 unit in <paramref name="TotalItems"/> and Sums <paramref name="value"/> to <paramref name="TotalValue" />.
		/// </summary>
		/// <param name="value"></param>
		public void AddItem(int value)
		{
			TotalItems++;
			TotalValue += value;
		}

        /// <summary>
        /// Shows in console the value stored in <paramref name="TotalItems" /> and <paramref name="TotalValue" />.
        /// </summary>
        public void PrintBag()
		{
			Console.WriteLine($"Bag total items: {TotalItems} | Bag total value: {TotalValue}");
		}

        /// <summary>
        /// Overrides ToString for showing Bag's status.
        /// </summary>
        /// <returns>Returns a string containing the Bag's status.</returns>
        public override string ToString()
		{
			return $"Bag total items: {TotalItems} | Bag total value: {TotalValue}";

        }
	}
}
