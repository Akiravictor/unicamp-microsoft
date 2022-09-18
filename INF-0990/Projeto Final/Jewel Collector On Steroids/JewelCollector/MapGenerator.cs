using JewelCollector.Consts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Board
{
	public class MapGenerator
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		
		private int Level { get; set; }

		private int Seed = 0;

		private static readonly int[] Hash = 
			{208,34,231,213,32,248,233,56,161,78,24,140,71,48,140,254,245,255,247,247,40,
			 185,248,251,245,28,124,204,204,76,36,1,107,28,234,163,202,224,245,128,167,204,
			 9,92,217,54,239,174,173,102,193,189,190,121,100,108,167,44,43,77,180,204,8,81,
			 70,223,11,38,24,254,210,210,177,32,81,195,243,125,8,169,112,32,97,53,195,13,
			 203,9,47,104,125,117,114,124,165,203,181,235,193,206,70,180,174,0,167,181,41,
			 164,30,116,127,198,245,146,87,224,149,206,57,4,192,210,65,210,129,240,178,105,
			 228,108,245,148,140,40,35,195,38,58,65,207,215,253,65,85,208,76,62,3,237,55,89,
			 232,50,217,64,244,157,199,121,252,90,17,212,203,149,152,140,187,234,177,73,174,
			 193,100,192,143,97,53,145,135,19,103,13,90,135,151,199,91,239,247,33,39,145,
			 101,120,99,3,186,86,99,41,237,203,111,79,220,135,158,42,30,154,120,67,87,167,
			 135,176,183,191,253,115,184,21,233,58,129,233,142,39,128,211,118,137,139,255,
			 114,20,218,113,154,27,127,246,250,1,8,198,250,209,92,222,173,21,88,102,219};

		public MapGenerator(int level)
		{
			Level = level;
		}

		private static int Noise(int x, int y)
		{
			var rand = new Random(Guid.NewGuid().GetHashCode());

			var seed = rand.Next();

			int tmp = Hash[ (y + seed) % 256 ];
			return Hash[ (tmp + x) % 256 ];
		}

		private static float LinInter(float x, float y, float s)
		{
			return x + s * (y - x);
		}

		private static float SmoothInter(float x, float y, float s)
		{
			return LinInter(x, y, s * s * (3 - 2 * s));
		}

		private static float Noise2d(float x, float y)
		{
			int x_int = (int)x;
			int y_int = (int)y;
			float x_frac = x - x_int;
			float y_frac = y - y_int;
			int s = Noise(x_int, y_int);
			int t = Noise(x_int + 1, y_int);
			int u = Noise(x_int, y_int + 1);
			int v = Noise(x_int + 1, y_int + 1);
			float low = SmoothInter(s, t, x_frac);
			float high = SmoothInter(u, v, x_frac);
			return SmoothInter(low, high, y_frac);
		}

		private static float Perlin2d(float x, float y, float freq, int depth)
		{
			float xa = x * freq;
			float ya = y * freq;
			float amp = 1.0f;
			float fin = 0;
			float div = 0.0f;

			for (int i = 0; i < depth; i++)
			{
				div += 256 * amp;
				fin += Noise2d(xa, ya) * amp;
				amp /= 2;
				xa *= 2;
				ya *= 2;
			}

			return fin / div;
		}

		private static float[,] GenerateNoise(int x, int y, float freq, int amp)
		{
			float[,] map = new float[x, y];

			for(int i = 0; i < x; i++)
			{
				for(int j = 0; j < y; j++)
				{
					map[i,j] = Perlin2d(i,j, freq, amp);
				}
			}

			return map;
		}

		private bool MapIsPlayable(string[,] grid, int height, int width)
		{
			//Run DFS to see if all Jewels are reachable


			return true;
		}

		public static string[,] GenerateMap(int height, int width)
		{
			var grid = new string[height, width];

			var obstacles = GenerateNoise(height, width, 0.1f, 1);
			var jewels = GenerateNoise(height, width, 0.3f, 1);
			var empty = GenerateNoise(height, width, 10f, 1);

			var tiles = new List<Tile>();
			var candidates = new List<Tile>();


			tiles.Add(new Tile
			{
				TileType = "JB",
				minObstacles = 0.4f,
				minJewels = 0.5f,
				minEmpty = 0.4f
			});

			tiles.Add(new Tile
			{
				TileType = "JG",
				minObstacles = 0.4f,
				minJewels = 0.4f,
				minEmpty = 0.2f
			});

			tiles.Add(new Tile
			{
				TileType = "JR",
				minObstacles = 0.6f,
				minJewels = 0.3f,
				minEmpty = 0.6f
			});

			tiles.Add(new Tile
			{
				TileType = "$$",
				minObstacles = 0.5f,
				minJewels = 0.5f,
				minEmpty = 0.5f
			});

			tiles.Add(new Tile
			{
				TileType = "##",
				minObstacles = 0.2f,
				minJewels = 0.3f,
				minEmpty = 0.5f
			});

			tiles.Add(new Tile
			{
				TileType = "!!",
				minObstacles = 0.7f,
				minJewels = 0.7f,
				minEmpty = 0.6f
			});

			tiles.Add(new Tile
			{
				TileType = "--",
				minObstacles = 0.5f,
				minJewels = 0.5f,
				minEmpty = 0.5f
			});

			Console.WriteLine("Obstacles:");
			for(int i= 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{
					Console.Write($"{(int)(obstacles[i,j] * 10)} ");
				}
				Console.WriteLine();
			}

			Console.WriteLine("\nJewels:");
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Console.Write($"{(int)(jewels[i, j] * 10)} ");
				}
				Console.WriteLine();
			}

			Console.WriteLine("\nEmpty:");
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Console.Write($"{(int)(empty[i, j] * 10)} ");
				}
				Console.WriteLine();
			}

			for (int i = 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{
					Tile selected = null;

					foreach (var tile in tiles)
					{
						if (obstacles[i, j] > tile.minObstacles && jewels[i, j] > tile.minJewels && empty[i, j] > tile.minEmpty)
						{
							candidates.Add(tile);
						}
					}

					foreach(var candidate in candidates)
					{					
						if(selected == null)
						{
							selected = candidate;
						}
						else if ((obstacles[i,j] - candidate.minObstacles) + (jewels[i,j] - candidate.minJewels) + (empty[i,j] - candidate.minEmpty) <
							(obstacles[i, j] - selected.minObstacles) + (jewels[i, j] - selected.minJewels) + (empty[i, j] - selected.minEmpty))
						{
							selected = candidate;
						}
					}

					if(selected == null)
					{
						grid[i, j] = "--";
					}
					else
					{
						grid[i, j] = selected.TileType;
					}
				}
			}

			return grid;
		}
	}

	public class Tile
	{
		public string TileType { get; set; } = "";
		public float minObstacles { get; set; }
		public float minJewels { get; set; }
		public float minEmpty { get; set; }


	}
}
