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
		public string Symbol { get; set; }

	}
}
