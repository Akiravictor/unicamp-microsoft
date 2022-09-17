using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using JewelCollector.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelCollector.Consts;

namespace JewelCollector.Board
{
	public class Map
	{
		/// <summary>
		/// Stores the state of the grid.
		/// </summary>
		public string[,] Grid { get; private set; }
		/// <summary>
		/// Stores the Height of the grid.
		/// </summary>
		public int Height { get; private set; }
		/// <summary>
		/// Stores the Width of the grid.
		/// </summary>
		public int Width { get; private set; }
		/// <summary>
		/// Stores a collection of <typeparamref name="Jewel" />.
		/// </summary>
		public List<Jewel> Jewels { get; private set; }
		/// <summary>
		/// Stores a collection of <typeparamref name="Obstacle" />.
		/// </summary>
		public List<Obstacle> Obstacles { get; private set; }

		/// <summary>
		/// Stores the current level
		/// </summary>
		public int Level { get; private set; }

		/// <summary>
		/// EventHandler for collecting a Jewel
		/// </summary>
		public event EventHandler? JewelCollected;


		/// <summary>
		/// Constructor for <typeparamref name="Map" />.
		/// Intializes an empty <paramref name="Grid"/> with the given <paramref name="height"/> and <paramref name="width"/>.
		/// </summary>
		/// <param name="height">Grid Height</param>
		/// <param name="width">Grid Width</param>
		public Map(int height, int width)
		{
			Height = height;
			Width = width;

			Grid = new string[height, width];

			for(int i = 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{
					Grid[i, j] = Symbols.Empty;
				}
			}

			Jewels = new List<Jewel>();
			Obstacles = new List<Obstacle>();

			Level = 1;

			Grid = MapGenerator.GenerateMap(height, width);

			PrintMap();

			Console.WriteLine();
		}

		/// <summary>
		/// Add a <typeparamref name="Jewel" /> to Collection <paramref name="Jewels"/>.
		/// </summary>
		/// <param name="jewel"></param>
		public void AddJewel(Jewel jewel)
		{
			Jewels.Add(jewel);
			Grid[jewel.X, jewel.Y] = jewel.Symbol;
		}

        /// <summary>
        /// Remove a <typeparamref name="Jewel" /> from Collection <paramref name="Jewels"/>.
        /// </summary>
        /// <param name="jewel"></param>
        public void RemoveJewel(Jewel jewel)
		{
			if(jewel.Color == EnumColor.Blue)
			{
				OnBlueJewelCollect(EventArgs.Empty);
			}
			 
			Jewels.Remove(jewel);
			Grid[jewel.X, jewel.Y] = Symbols.Empty;
		}

        /// <summary>
        /// Add an <typeparamref name="Obstacle" /> to Collection <paramref name="Obstacles"/>.
        /// </summary>
        /// <param name="obstacle"></param>
        public void AddObstacle(Obstacle obstacle)
		{
			Obstacles.Add(obstacle);
			Grid[obstacle.X, obstacle.Y] = obstacle.Symbol;
		}

        /// <summary>
        /// Remove an <typeparamref name="Obstacle" /> from Collection <paramref name="Obstacles"/>.
        /// </summary>
        /// <param name="obstacle"></param>
        public void RemoveObstacle(Obstacle obstacle)
		{
			Obstacles.Remove(obstacle);
			Grid[obstacle.X, obstacle.Y] = Symbols.Empty;
		}

		/// <summary>
		/// Shows the <paramref name="Grid" /> in Console.
		/// </summary>
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

        /// <summary>
        /// Overrides ToString for showing Grid.
        /// </summary>
        /// <returns>Returns a string containing the Grid.</returns>
        public override string ToString()
		{
			StringBuilder sb = new();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append($"{Grid[i, j]}  ");
                }
                sb.Append('\n');
            }

            return sb.ToString();
		}

		/// <summary>
		/// Event for Collecting a BlueJewel
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnBlueJewelCollect(EventArgs e)
		{
			var raiseEvent = JewelCollected;

			if(raiseEvent != null)
			{
				raiseEvent(this, e);
			}
		}
	}
}
