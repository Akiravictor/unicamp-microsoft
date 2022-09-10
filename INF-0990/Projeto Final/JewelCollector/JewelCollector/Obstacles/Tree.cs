using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
	public class Tree : Obstacle
	{
        /// <summary>
        /// Constructor for <typeparamref name="Tree Obstacle" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tree(int x, int y) : base(x, y, EnumObstacle.Tree)
		{

		}
	}
}
