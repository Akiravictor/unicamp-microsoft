using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Green : Jewel
	{
        /// <summary>
        /// Constructor for <typeparamref name="Green Jewel" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Green(int x, int y) : base(x, y, 50, EnumColor.Green)
		{
			
		}
	}
}
