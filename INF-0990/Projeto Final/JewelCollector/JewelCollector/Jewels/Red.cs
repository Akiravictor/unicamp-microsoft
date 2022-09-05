using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Red : Jewel
	{
		public Red(int x, int y)
		{
			base.X = x;
			base.Y = y;
			base.Value = 100;
			base.Symbol = "JR";
		}
	}
}
