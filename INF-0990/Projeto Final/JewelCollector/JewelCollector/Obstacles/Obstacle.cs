using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
	public abstract class Obstacle
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Symbol { get; set; } = "";

		public Obstacle(int x, int y, EnumObstacle obstacle)
		{
			X = x;
			Y = y;

			switch (obstacle)
			{
				case EnumObstacle.Tree:
					Symbol = "$$";
					break;

				case EnumObstacle.Water:
					Symbol = "##";
					break;
			}
		}
	}
}
