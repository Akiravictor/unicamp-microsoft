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

		private static int Seed = 0;

		private static int[] Hash = 
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

			var rand = new Random();
			Seed = rand.Next();
			Level = level;
		}

		private static int noise(int x, int y)
		{
			int tmp = Hash[ (y + Seed) % 256 ];
			return Hash[ (tmp + x) % 256 ];
		}

		private static float lin_inter(float x, float y, float s)
		{
			return x + s * (y - x);
		}

		private static float smooth_inter(float x, float y, float s)
		{
			return lin_inter(x, y, s * s * (3 - 2 * s));
		}

		private static float noise2d(float x, float y)
		{
			int x_int = (int)x;
			int y_int = (int)y;
			float x_frac = x - x_int;
			float y_frac = y - y_int;
			int s = noise(x_int, y_int);
			int t = noise(x_int + 1, y_int);
			int u = noise(x_int, y_int + 1);
			int v = noise(x_int + 1, y_int + 1);
			float low = smooth_inter(s, t, x_frac);
			float high = smooth_inter(u, v, x_frac);
			return smooth_inter(low, high, y_frac);
		}

		private static float perlin2d(float x, float y, float freq, int depth)
		{
			float xa = x * freq;
			float ya = y * freq;
			float amp = 1.0f;
			float fin = 0;
			float div = 0.0f;

			for (int i = 0; i < depth; i++)
			{
				div += 256 * amp;
				fin += noise2d(xa, ya) * amp;
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
					map[i,j] = perlin2d(i,j, freq, amp);
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

			var obstacles = GenerateNoise(height, width, 0.1f, 2);
			var jewels = GenerateNoise(height, width, 0.3f, 3);
			var empty = GenerateNoise(height, width, 0.5f, 4);

			var minBlueJewel = new
			{
				minObstacles = 0.4f,
				minJewels = 0.2f,
				minEmpty = 0.1f
			};

			var minGreenJewel = new
			{
				minObstacles = 0.4f,
				minJewels = 0.7f,
				minEmpty = 0.2f
			};

			var minRedJewel = new
			{
				minObstacles = 0.6f,
				minJewels = 0.3f,
				minEmpty = 0.7f
			};

			var minTree = new
			{
				minObstacles = 0.2f,
				minJewels = 0.2f,
				minEmpty = 0.2f
			};

			var minWater = new
			{
				minObstacles = 0.4f,
				minJewels = 0.5f,
				minEmpty = 0.1f
			};

			var minRadiation = new
			{
				minObstacles = 0.4f,
				minJewels = 0.3f,
				minEmpty = 0.4f
			};

			var minEmpty = new
			{
				minObstacles = 0.5f,
				minJewels = 0.5f,
				minEmpty = 0.5f
			};

			for(int i = 0; i < height; i++)
			{
				for(int j = 0; j < width; j++)
				{

				}
			}

			return grid;
		}
	}
}
