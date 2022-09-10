using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
	public class Water : Obstacle
	{
        /// <summary>
        /// Constructor for <typeparamref name="Water Obstacle" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Water(int x, int y) : base(x, y, EnumObstacle.Water)
		{
			
		}
	}
}
