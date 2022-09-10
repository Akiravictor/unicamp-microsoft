using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Red : Jewel
	{
        /// <summary>
        /// Constructor for <typeparamref name="Red Jewel" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Red(int x, int y) : base(x, y, 100, EnumColor.Red)
		{
			
		}
	}
}
