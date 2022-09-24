using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using JewelCollector.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelCollector.Consts;
using System.Net.Http.Headers;

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

		private MapGenerator MapGen { get; set; }

		/// <summary>
		/// EventHandler for collecting a Jewel
		/// </summary>
		public event EventHandler? JewelCollected;

		/// <summary>
		/// EventHandler for clearing the level
		/// </summary>
		public event EventHandler? LevelCleared;

		public event EventHandler? GameCleared;

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

			Level = 1;
			MapGen = new MapGenerator();

			Grid = MapGen.GenerateMap(Height, Width, Level);
			Jewels = MapGen.Jewels.ToList();
			Obstacles = MapGen.Obstacles.ToList();
		}

		public void LevelUp()
		{
			Level += 1;

			Height += 1;
			Width += 1;

			if(Height > 30 || Width > 30)
			{
				OnGameClear();
			}

			MapGen.Reset();
		}

		public void ResetLevel()
		{
			Level = 1;

			Height = 10;
			Width = 10;

			MapGen.Reset();
		}

		public void GenerateMap()
		{
			Grid = MapGen.GenerateMap(Height, Width, Level);

			if(Jewels != null)
			{
				Jewels.Clear();
			}

			if(Obstacles != null)
			{
				Obstacles.Clear();
			}

			Jewels = MapGen.Jewels.ToList();
			Obstacles = MapGen.Obstacles.ToList();
			
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
			Jewels.Remove(jewel);
			
			if(Jewels.Count == 0)
			{
				OnClearLevel();
			}
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

		public void RefreshMap(int robotX, int robotY)
		{
			for(int i = 0; i < Height; i++)
			{
				for(int j = 0; j < Width; j++)
				{
					Grid[i, j] = Symbols.Empty;
				}
			}

			foreach (var jewel in Jewels)
			{
				Grid[jewel.X, jewel.Y] = jewel.Symbol;
			}

			foreach (var obstacle in Obstacles)
			{
				Grid[obstacle.X, obstacle.Y] = obstacle.Symbol;
			}

			Grid[robotX, robotY] = Symbols.Robot;

		}

		protected virtual void OnClearLevel()
		{
			var raiseEvent = LevelCleared;

			if(raiseEvent != null)
			{
				raiseEvent(this, EventArgs.Empty);
			}
		}

		protected virtual void OnGameClear()
		{
			var raiseEvent = GameCleared;

			if(raiseEvent != null)
			{
				raiseEvent(this, EventArgs.Empty);
			}
		}
	}
}
