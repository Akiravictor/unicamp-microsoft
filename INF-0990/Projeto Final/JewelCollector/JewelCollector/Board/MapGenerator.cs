using JewelCollector.Consts;
using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Board
{
    public class MapGenerator
    {
        private int Level { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }

        private List<Obstacle> Obstacles { get; private set;}
        private List<Jewel> Jewels { get; private set; }

        private const int NumTrees = 5;
        private const int NumWater = 5;
        private const int NumRadiation = 3;
        private const int NumBlueJewel = 5;
        private const int NumGreenJewel = 5;
        private const int NumRedJewel = 5;


        public MapGenerator(int level, int height, int width)
        {
            Level = level;
            Height = height;
            Width = width;
        }

        public void LevelUp()
        {
            Level++;
        }

        public string[,] GenerateMap()
        {
            Height = Height + Level - 1;
            Width = Width + Level - 1;

            var grid = new string[Height, Width];
            var IsPlayable = false;

            Obstacles = new List<Obstacle>();
            Jewels = new List<Jewel>();

            var random = new Random(Guid.NewGuid().GetHashCode());

            do
            {
                for (int i = 0; i < (NumTrees * Level); i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
                    Obstacles.Add(new Tree(x, y));
                    grid[x, y] = Symbols.Tree;
                }

                for (int i = 0; i < (NumWater * Level); i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
                    Obstacles.Add(new Water(x, y));
                    grid[x, y] = Symbols.Water;
                }

                for (int i = 0; i < (NumRadiation * (Level - 1)); i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
                    Obstacles.Add(new Radiation(x, y));
                    grid[x, y] = Symbols.Radiation;
                }

                for (int i = 0; i < (NumBlueJewel * Level) - 3; i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
                    Jewels.Add(new Blue(x, y));
                    grid[x, y] = Symbols.BlueJewel;
                }

                for (int i = 0; i < (NumGreenJewel * Level) - 3; i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
                    Jewels.Add(new Green(x, y));
                    grid[x, y] = Symbols.GreenJewel;
                }

                for (int i = 0; i < (NumRedJewel * Level) - 3; i++)
                {
                    var x = random.Next(Height);
                    var y = random.Next(Width);
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
                    Jewels.RemoveRange(0, Jewels.Count);
                    Obstacles.RemoveRange(0, Obstacles.Count);

                }
            } while (!IsPlayable);

            return grid;
        }

        private bool MapIsPlayeble(string[,] grid)
        {
            var queue = new Queue<Axis>();

            queue.Enqueue(new Axis(0,0));
            grid[0, 0] = "x";

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                var neighbors = Neighbors(node.X, node.Y, grid);

                foreach(var neighbor in neighbors)
                {
                    if (grid[neighbor.X, neighbor.Y] != "x")
                    {
                        queue.Enqueue(neighbor);
                    }
                }

            }

            return true;
        }

        private List<Axis> Neighbors(int x, int y, string[,] grid)
        {
            var axes = new List<Axis>();

            if(x - 1 > -1 && grid[x - 1, y].Equals("--") || x - 1 > -1 && grid[x - 1, y].Equals("!!"))
            {
                axes.Add(new Axis(x - 1, y));
            }
            
            if(x + 1 < Height && grid![x + 1, y].Equals("--") || x + 1 < Height && grid![x + 1, y].Equals("!!"))
            {
                axes.Add(new Axis(x + 1, y));
            }

            if(y - 1 > -1 && grid[x, y - 1].Equals("--") || y - 1 > -1 && grid[x, y - 1].Equals("!!"))
            {
                axes.Add(new Axis(x, y - 1));
            }

            if(y + 1 < Width && grid![x, y + 1].Equals("--") || y + 1 < Width && grid![x, y + 1].Equals("!!"))
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
