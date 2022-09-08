using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public abstract class Jewel
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Value { get; set; }
		public string Symbol { get; set; } = "";

		public Jewel(int x, int y, int value, EnumColor color)
		{
			X = x;
			Y = y;
			Value = value;

			switch (color)
			{
				case EnumColor.Red:
					Symbol = "JR";
					break;

				case EnumColor.Blue:
					Symbol = "JB";
					break;

				case EnumColor.Green:
					Symbol = "JG";
					break;
			}
		}

	}
}
