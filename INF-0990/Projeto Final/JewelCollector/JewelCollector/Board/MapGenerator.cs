using JewelCollector.Consts;
using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Board
{
    public class MapGenerator
    {
        /// <summary>
		/// Stores a collection of <typeparamref name="Obstacle" />.
		/// </summary>
        public List<Obstacle> Obstacles { get; private set;}

        /// <summary>
		/// Stores a collection of <typeparamref name="Jewel" />.
		/// </summary>
        public List<Jewel> Jewels { get; private set; }

        /// <summary>
        /// Stores the Map's Height.
        /// </summary>
        private int Height;

        /// <summary>
        /// Stores the Map's Width.
        /// </summary>
		private int Width;

        /// <summary>
        /// Stores the Map's Level.
        /// </summary>
		private int Level;

        /// <summary>
        /// Constant for the base number of Trees.
        /// </summary>
        private const int NumTrees = 5;

        /// <summary>
        /// Constant for the base number of Water.
        /// </summary>
        private const int NumWater = 5;

        /// <summary>
        /// Constant for the base number of Radiation.
        /// </summary>
        private const int NumRadiation = 3;

        /// <summary>
        /// Constant for the base number of Blue Jewels.
        /// </summary>
        private const int NumBlueJewel = 5;

        /// <summary>
        /// Constant for the base number of Green Jewels.
        /// </summary>
        private const int NumGreenJewel = 5;

        /// <summary>
        /// Constant for the base number of Red Jewels.
        /// </summary>
        private const int NumRedJewel = 5;

        /// <summary>
        /// Constructor for <typeparamref name="MapGenerator" />.
        /// </summary>
        public MapGenerator()
        {
            Jewels = new List<Jewel>();
            Obstacles = new List<Obstacle>();

        }

        /// <summary>
        /// Resets MapGenerator's properties.
        /// </summary>
        public void Reset()
        {
            Jewels.Clear();
            Obstacles.Clear();
        }

        /// <summary>
        /// Generates a playable Map given its <paramref name="height"/>, <paramref name="width"/> and <paramref name="level"/>.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="level"></param>
        /// <returns>Returns a matrix with size of <paramref name="height"/> by <paramref name="width"/> increased by <paramref name="level"/>.</returns>
        public string[,] GenerateMap(int height, int width, int level)
        {
            Level = level;
            Height = height;
            Width = width;

            var grid = new string[Height, Width];
            var IsPlayable = false;

            var random = new Random(Guid.NewGuid().GetHashCode());

            do
            {
                // Randomly adds Trees
                for (int i = 0; i < (NumTrees + Level); i++)
                {
                    int x;
                    int y;

                    do
                    {
                        x = random.Next(Height);
                        y = random.Next(Width);

                    }while(x == 0 && y == 0);

                    Obstacles.Add(new Tree(x, y));
                    grid[x, y] = Symbols.Tree;
                }

                //Randomly adds Water on empty positions
                for (int i = 0; i < (NumWater + Level); i++)
                {
                    int x;
                    int y;
                    
                    do
                    {
                        x = random.Next(Height);
                        y = random.Next(Width);

                    } while (!string.IsNullOrEmpty(grid[x, y]));

                    Obstacles.Add(new Water(x, y));
                    grid[x, y] = Symbols.Water;
                }

                if(Level > 1)
                {
                    //Randomly adds Radiation on empty positions
                    for (int i = 0; i < (NumRadiation + Level); i++)
                    {
					    int x;
					    int y;

                        do
                        {
					        x = random.Next(Height);
                            y = random.Next(Width);

                        } while (!string.IsNullOrEmpty(grid[x, y]));

                        Obstacles.Add(new Radiation(x, y));
                        grid[x, y] = Symbols.Radiation;
                    }
                }

                //Randomly adds Blue Jewels on empty positions
                for (int i = 0; i < (NumBlueJewel + Level); i++)
                {
					int x;
					int y;

					do
					{
						x = random.Next(Height);
						y = random.Next(Width);

					} while (!string.IsNullOrEmpty(grid[x, y]));

					Jewels.Add(new Blue(x, y));
                    grid[x, y] = Symbols.BlueJewel;
                }

                //Randomly adds Green Jewels on empty positions
                for (int i = 0; i < (NumGreenJewel + Level); i++)
                {
					int x;
					int y;

					do
					{
						x = random.Next(Height);
						y = random.Next(Width);

					} while (!string.IsNullOrEmpty(grid[x, y]));

					Jewels.Add(new Green(x, y));
                    grid[x, y] = Symbols.GreenJewel;
                }

                //Randomly adds Red Jewels on empty positions
                for (int i = 0; i < (NumRedJewel + Level); i++)
                {
					int x;
					int y;

					do
					{
						x = random.Next(Height);
						y = random.Next(Width);

					} while (!string.IsNullOrEmpty(grid[x, y]));

					Jewels.Add(new Red(x, y));
                    grid[x, y] = Symbols.RedJewel;
                }

                //Fill all empty positions with Empty Symbol
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (string.IsNullOrEmpty(grid[i, j]))
                        {
                            grid[i, j] = Symbols.Empty;
                        }
                    }
                }

                //Verify if the map is playable
                if (MapIsPlayeble(grid))
                {
                    IsPlayable = true;
                }
                else
                {
                    Jewels.Clear();
                    Obstacles.Clear();

					for (int i = 0; i < Height; i++)
					{
						for (int j = 0; j < Width; j++)
						{
                            grid[i, j] = "";
						}
					}

				}
            } while (!IsPlayable);

            //Resets Jewels positions
            foreach(var jewel in Jewels)
            {
                grid[jewel.X, jewel.Y] = jewel.Symbol;
            }

            //Resets Obstacles positions
			foreach (var obstacle in Obstacles)
			{
				grid[obstacle.X, obstacle.Y] = obstacle.Symbol;
			}

            //Resets empty positions
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					if(grid[i, j] == "xx")
                    {
                        grid[i, j] = "--";

					}
				}
			}

			return grid;
        }

        /// <summary>
        /// Uses Breadth-First Search (BFS) algorithm to verify if all Jewels are reachable. 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>Returns <typeparamref name="True" /> if the all Jewels in the map are reachable.</returns>
        private bool MapIsPlayeble(string[,] grid)
        {
            var queue = new Queue<Axis>();
            var jewelsLocal = new List<Jewel>();

            //Locally creates a jewel list
            foreach(var j in Jewels)
            {
                jewelsLocal.Add(j);
            }

            //BFS Algorithm
            queue.Enqueue(new Axis(0,0));
            grid[0, 0] = "xx";

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                var neighbors = Neighbors(node.X, node.Y, grid);

				foreach (var neighbor in neighbors)
                {
                    if (grid[neighbor.X, neighbor.Y] != "xx" && grid[neighbor.X, neighbor.Y] != "oo")
                    {
						if (grid[neighbor.X, neighbor.Y] == "JB" || grid[neighbor.X, neighbor.Y] == "JG" || grid[neighbor.X, neighbor.Y] == "JR")
						{
							var jewel = Jewels.First(j => j.X == neighbor.X && j.Y == neighbor.Y);
							jewelsLocal.Remove(jewel);
						}

						grid[neighbor.X, neighbor.Y] = "oo";
                        queue.Enqueue(neighbor);
                    }
                }

                grid[node.X, node.Y] = "xx";

			}

            if(jewelsLocal.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get all valid neighbors for the given position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="grid"></param>
        /// <returns>Returns a <typeparamref name="List" /> of <typeparamref name="Axis" /> with all valid neighbors.</returns>
        private List<Axis> Neighbors(int x, int y, string[,] grid)
        {
            var axes = new List<Axis>();

            if((x - 1 > -1 && !grid[x - 1, y].Equals("##")) && (x - 1 > -1 && !grid[x - 1, y].Equals("$$")) && (x - 1 > -1 && !grid[x - 1, y].Equals("xx")))
            {
                axes.Add(new Axis(x - 1, y));
            }
            
            if((x + 1 < Height && !grid![x + 1, y].Equals("##")) && (x + 1 < Height && !grid![x + 1, y].Equals("$$")) && (x + 1 < Height && !grid![x + 1, y].Equals("xx")))
            {
                axes.Add(new Axis(x + 1, y));
            }

            if((y - 1 > -1 && !grid[x, y - 1].Equals("##")) && (y - 1 > -1 && !grid[x, y - 1].Equals("$$")) && (y - 1 > -1 && !grid[x, y - 1].Equals("xx")))
            {
                axes.Add(new Axis(x, y - 1));
            }

            if((y + 1 < Width && !grid![x, y + 1].Equals("##")) && (y + 1 < Width && !grid![x, y + 1].Equals("$$")) && (y + 1 < Width && !grid![x, y + 1].Equals("xx")))
            {
                axes.Add(new Axis(x, y + 1));
            }

            return axes;
        }
    }

    internal class Axis
    {
        /// <summary>
        /// Stores the X value in the map.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Stores the Y value in the map.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Constructor for <typeparamref name="Axis" />
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Axis(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
