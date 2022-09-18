using JewelCollector.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
	public abstract class Obstacle
	{
        /// <summary>
        /// Stores the X position of an <typeparamref name="Obstacle" /> in the Grid.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Stores the Y position of an <typeparamref name="Obstacle" /> in the Grid.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Stores the Symbol of an <typeparamref name="Obstacle" />.
        /// </summary>
        public string Symbol { get; set; } = "";

        public EnumObstacle Type { get; private set; }

        /// <summary>
        /// Constructor for <typeparamref name="Obstacle" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="obstacle"></param>
        public Obstacle(int x, int y, EnumObstacle obstacle)
		{
			X = x;
			Y = y;
            Type = obstacle;

			switch (obstacle)
			{
				case EnumObstacle.Tree:
					Symbol = Symbols.Tree;
					break;

				case EnumObstacle.Water:
					Symbol = Symbols.Water;
					break;

                case EnumObstacle.Radiation:
                    Symbol = Symbols.Radiation;
                    break;
			}
		}
	}
}
