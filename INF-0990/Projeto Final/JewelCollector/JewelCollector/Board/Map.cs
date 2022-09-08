using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using JewelCollector.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Board
{
	public class Map
	{
		public string[,] Grid { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public List<Jewel> Jewels { get; set; }
		public List<Obstacle> Obstacles { get; set; }

		public Map(int height, int width)
		{
			Height = height;
			Width = width;

			Grid = new string[height, width];

			for(int i = 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{
					Grid[i, j] = "--";
				}
			}

			Jewels = new List<Jewel>();
			Obstacles = new List<Obstacle>();
		}

		public void AddJewel(Jewel jewel)
		{
			Jewels.Add(jewel);
			Grid[jewel.X, jewel.Y] = jewel.Symbol;
		}

		public void RemoveJewel(Jewel jewel)
		{
			Jewels.Remove(jewel);
			Grid[jewel.X, jewel.Y] = "--";
		}

		public void AddObstacle(Obstacle obstacle)
		{
			Obstacles.Add(obstacle);
			Grid[obstacle.X, obstacle.Y] = obstacle.Symbol;
		}

		public void RemoveObstacle(Obstacle obstacle)
		{
			Obstacles.Remove(obstacle);
			Grid[obstacle.X, obstacle.Y] = "--";
		}

		public void PrintMap()
		{
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					Console.Write($"{Grid[i, j]}  ");
				}
				Console.WriteLine();
			}
		}
	}
}
