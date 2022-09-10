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
        /// <summary>
        /// Stores the X position of the <typeparamref name="Robot" /> in the Grid.
        /// </summary>
        private int X { get; set; }

        /// <summary>
        /// Stores the Y position of the <typeparamref name="Robot" /> in the Grid.
        /// </summary>
        private int Y { get; set; }

		/// <summary>
		/// <typeparamref name="Bag" /> for storing the collected items.
		/// </summary>
		private Bag Bag { get; set; }

        /// <summary>
        /// Constructor for <typeparamref name="Robot" />
		/// Sets the robot in position (0,0) in the Grid.
        /// </summary>
        /// <param name="map"></param>
        public Robot(Map map)
		{
			Bag = new Bag();
			map.Grid[0, 0] = "ME";
		}

		/// <summary>
		/// Moves the robot 1 position Up in the Grid.
		/// </summary>
		/// <param name="map"></param>
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

		/// <summary>
		/// Moves the robot 1 position Down in the Grid.
		/// </summary>
		/// <param name="map"></param>
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

		/// <summary>
		/// Moves the robot 1 position Right in the Grid.
		/// </summary>
		/// <param name="map"></param>
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

		/// <summary>
		/// Moves the robot 1 position Left in the Grid.
		/// </summary>
		/// <param name="map"></param>
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

		/// <summary>
		/// Collect a <typeparamref name="Jewel" /> that is adjacent to the robot.
		/// </summary>
		/// <param name="map"></param>
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

		/// <summary>
		///	Shows in Console the values in <typeparamref name="Bag" />.
		/// </summary>
		public void PrintBag()
		{
			Bag.PrintBag();
		}

		/// <summary>
		/// Verifies the Up cell, relative to the robot, if it contains <paramref name="str"/>.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="str"></param>
		/// <returns>Returns true if <paramref name="str"/> is found in the cell, else false.</returns>
		private bool CheckUpFor(Map map, string str)
		{
			return X - 1 > -1 && map.Grid[X - 1, Y].Equals(str);
		}

        /// <summary>
        /// Verifies the Down cell, relative to the robot, if it contains <paramref name="str"/>.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="str"></param>
        /// <returns>Returns true if <paramref name="str"/> is found in the cell, else false.</returns>
        private bool CheckDownFor(Map map, string str)
		{
			return X + 1 < map.Height && map.Grid![X + 1, Y].Equals(str);
		}

        /// <summary>
        /// Verifies the Left cell, relative to the robot, if it contains <paramref name="str"/>.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="str"></param>
        /// <returns>Returns true if <paramref name="str"/> is found in the cell, else false.</returns>
        private bool CheckLeftFor(Map map, string str)
		{
			return Y - 1 > -1 && map.Grid[X, Y - 1].Equals(str);
		}

        /// <summary>
        /// Verifies the Right cell, relative to the robot, if it contains <paramref name="str"/>.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="str"></param>
        /// <returns>Returns true if <paramref name="str"/> is found in the cell, else false.</returns>
        private bool CheckRightFor(Map map, string str)
		{
			return Y + 1 < map.Width && map.Grid![X, Y + 1].Equals(str);
		}
	}
}
