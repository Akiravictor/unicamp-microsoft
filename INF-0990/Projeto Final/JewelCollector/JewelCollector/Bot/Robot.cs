using JewelCollector.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot
{
	public class Robot
	{
		private int X { get; set; }
		private int Y { get; set; }
		private Bag Bag { get; set; }

		public Robot(Map map)
		{
			Bag = new Bag();
			map.Grid[0, 0] = "ME";
		}

		public void MoveUp(Map map)
		{
			if(CheckUpFor(map, "--"))
			{
				map.Grid[X, Y] = "--";
				X--;
				map.Grid[X, Y] = "ME";
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(1500);
			}
		}

		public void MoveDown(Map map)
		{
			if(CheckDownFor(map, "--"))
			{
				map.Grid[X, Y] = "--";
				X++;
				map.Grid[X, Y] = "ME";
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(1500);
			}
		}

		public void MoveRight(Map map)
		{
			if(CheckRightFor(map, "--"))
			{
				map.Grid[X, Y] = "--";
				Y++;
				map.Grid[X, Y] = "ME";
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(1500);
			}
		}

		public void MoveLeft(Map map)
		{
			if(CheckLeftFor(map, "--"))
			{
				map.Grid[X, Y] = "--";
				Y--;
				map.Grid[X, Y] = "ME";
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(1500);
			}
		}

		public void CollectJewel(Map map)
		{
			if(CheckUpFor(map, "JB") || CheckUpFor(map, "JG") || CheckUpFor(map, "JR"))
			{
				var jewel = map.Jewels.First(jewel => jewel.X == X - 1 && jewel.Y == Y);
				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);
			}
			else if (CheckDownFor(map, "JB") || CheckDownFor(map, "JG") || CheckDownFor(map, "JR"))
			{
				var jewel = map.Jewels.First(jewel => jewel.X == X + 1 && jewel.Y == Y);
				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);
			}
			else if (CheckLeftFor(map, "JB") || CheckLeftFor(map, "JG") || CheckLeftFor(map, "JR"))
			{
				var jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y - 1);
				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);
			}
			else if (CheckRightFor(map, "JB") || CheckRightFor(map, "JG") || CheckRightFor(map, "JR"))
			{
				var jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y + 1);
				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);
			}
		}

		public void PrintBag()
		{
			Bag.PrintBag();
		}

		private bool CheckUpFor(Map map, string str)
		{
			return X - 1 > -1 && map.Grid[X - 1, Y].Equals(str);
		}

		private bool CheckDownFor(Map map, string str)
		{
			return X + 1 < map.Height && map.Grid![X + 1, Y].Equals(str);
		}

		private bool CheckLeftFor(Map map, string str)
		{
			return Y - 1 > -1 && map.Grid[X, Y - 1].Equals(str);
		}

		private bool CheckRightFor(Map map, string str)
		{
			return Y + 1 < map.Width && map.Grid![X, Y + 1].Equals(str);
		}
	}
}
