using JewelCollector.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Blue : Jewel
	{
        /// <summary>
        /// Constructor for <typeparamref name="Blue Jewel" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Blue(int x, int y) : base(x, y, 10, EnumColor.Blue)
		{ 
		
		}
	}
}
