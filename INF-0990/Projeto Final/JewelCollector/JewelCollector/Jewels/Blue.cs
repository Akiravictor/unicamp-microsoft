using JewelCollector.Board;
using JewelCollector.Consts;
using JewelCollector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public class Blue : Jewel, IRechargeable
	{
        /// <summary>
        /// Constructor for <typeparamref name="Blue Jewel" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Blue(int x, int y) : base(x, y, 10, EnumColor.Blue)
		{ 
		
		}

        /// <summary>
        /// Returns the amount of energy given by a Blue Jewel.
        /// </summary>
        /// <returns>Returns an <typeparamref name="int" /> representing the amount of energy given by a Blue Jewel.</returns>
        public int RechargeEnergy()
		{
			return EnergyAmount.BlueEnergy;
		}
	}
}
