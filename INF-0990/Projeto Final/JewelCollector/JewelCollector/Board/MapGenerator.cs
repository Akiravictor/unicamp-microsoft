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
        public List<Obstacle> Obstacles { get; private set;}
        public List<Jewel> Jewels { get; private set; }

        private int Height;
		private int Width;
		private int Level;

        private const int NumTrees = 5;
        private const int NumWater = 5;
        private const int NumRadiation = 3;
        private const int NumBlueJewel = 5;
        private const int NumGreenJewel = 5;
        private const int NumRedJewel = 5;

        public MapGenerator()
        {
            Jewels = new List<Jewel>();
            Obstacles = new List<Obstacle>();

        }

        public void Reset()
        {
            Jewels.Clear();
            Obstacles.Clear();
        }

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
                for (int i = 0; i < (NumTrees * Level); i++)
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

                for (int i = 0; i < (NumWater * Level); i++)
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

                for (int i = 0; i < (NumRadiation * (Level - 1)); i++)
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

                for (int i = 0; i < (NumBlueJewel * Level) - 3; i++)
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

                for (int i = 0; i < (NumGreenJewel * Level) - 3; i++)
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

                for (int i = 0; i < (NumRedJewel * Level) - 3; i++)
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

            foreach(var jewel in Jewels)
            {
                grid[jewel.X, jewel.Y] = jewel.Symbol;
            }

			foreach (var obstacle in Obstacles)
			{
				grid[obstacle.X, obstacle.Y] = obstacle.Symbol;
			}

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

        private bool MapIsPlayeble(string[,] grid)
        {
            var queue = new Queue<Axis>();
            var jewelsLocal = new List<Jewel>();

            foreach(var j in Jewels)
            {
                jewelsLocal.Add(j);
            }

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
        public int X { get; set; }

        public int Y { get; set; }

        public Axis(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
