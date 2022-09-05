using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Green : Jewel
	{
		public Green(int x, int y)
		{
			base.X = x;
			base.Y = y;
			base.Value = 50;
			base.Symbol = "JG";
		}
	}
}
