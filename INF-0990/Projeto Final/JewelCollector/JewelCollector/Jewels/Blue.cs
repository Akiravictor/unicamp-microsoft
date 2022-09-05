using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Blue : Jewel
	{
		public Blue(int x, int y)
		{
			base.X = x;
			base.Y = y;
			base.Value = 10;
			base.Symbol = "JB";
		}
	}
}
