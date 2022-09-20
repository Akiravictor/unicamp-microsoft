using JewelCollector.Board;
using JewelCollector.Consts;
using JewelCollector.Jewels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot
{
	public class Robot : IInteraction
	{
        /// <summary>
        /// Stores the X position of the <typeparamref name="Robot" /> in the Grid.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Stores the Y position of the <typeparamref name="Robot" /> in the Grid.
        /// </summary>
        public int Y { get; private set; }

		/// <summary>
		/// <typeparamref name="Bag" /> for storing the collected items.
		/// </summary>
		public Bag Bag { get; private set; }

		/// <summary>
		/// Robot's energy
		/// </summary>
		public int Energy { get; private set; }

		/// <summary>
		/// Robot's Moved event
		/// </summary>
		public event EventHandler RobotMoved;

		/// <summary>
		/// Robot's Interaction event
		/// </summary>
		public event EventHandler RobotInteracted;

		/// <summary>
		/// Event for Energy depleted
		/// </summary>
		public event EventHandler EnergyDepleted;

        /// <summary>
        /// Constructor for <typeparamref name="Robot" />
		/// Sets the robot in position (0,0) in the Grid.
        /// </summary>
        /// <param name="map"></param>
        public Robot(Map map)
		{
			Bag = new Bag();
			map.Grid[0, 0] = Symbols.Robot;
			Energy = 5;

			map.JewelCollected += Map_BlueJewelCollected;
		}

		public void ResetRobot(Map map)
		{
			Bag.ResetBag();
			map.Grid[0, 0] = Symbols.Robot;

			X = 0;
			Y = 0;
			Energy = 5;

		}

		/// <summary>
		/// Event handling for Blue Jewel Collected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Map_BlueJewelCollected(object? sender, EventArgs e)
		{
			RechargeEnergy(5);
		}

		#region [Movement]

		/// <summary>
		/// Move robot accordingly to <paramref name="moveTo"/>.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="moveTo"></param>
		public void Move(Map map, EnumMove moveTo)
		{
			if(Energy > 0)
			{
				switch (moveTo)
				{
					case EnumMove.Up:
						MoveUp(map);
						break;

					case EnumMove.Down:
						MoveDown(map);
						break;

					case EnumMove.Right:
						MoveRight(map);
						break;

					case EnumMove.Left:
						MoveLeft(map);
						break;
				}

				
				OnRobotMoved(EventArgs.Empty);
			}
			else
			{
				Console.WriteLine("Not more Energy available...");

				OnEnergyDepleted();
			}

		}

		/// <summary>
		/// Moves the robot 1 position Up in the Grid.
		/// </summary>
		/// <param name="map"></param>
		private void MoveUp(Map map)
		{
			if(CheckUpFor(map, Symbols.Empty))
			{
				map.Grid[X, Y] = Symbols.Empty;
				X--;
				map.Grid[X, Y] = Symbols.Robot;
				Energy -= 1;
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(300);
			}
		}

        /// <summary>
        /// Moves the robot 1 position Down in the Grid.
        /// </summary>
        /// <param name="map"></param>
        private void MoveDown(Map map)
		{
			if(CheckDownFor(map, Symbols.Empty))
			{
				map.Grid[X, Y] = Symbols.Empty;
				X++;
				map.Grid[X, Y] = Symbols.Robot;
				Energy -= 1;
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(300);
			}
		}

        /// <summary>
        /// Moves the robot 1 position Right in the Grid.
        /// </summary>
        /// <param name="map"></param>
        private void MoveRight(Map map)
		{
			if(CheckRightFor(map, Symbols.Empty))
			{
				map.Grid[X, Y] = Symbols.Empty;
				Y++;
				map.Grid[X, Y] = Symbols.Robot;
				Energy -= 1;
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(300);
			}
		}

        /// <summary>
        /// Moves the robot 1 position Left in the Grid.
        /// </summary>
        /// <param name="map"></param>
        private void MoveLeft(Map map)
		{
			if(CheckLeftFor(map, Symbols.Empty))
			{
				map.Grid[X, Y] = Symbols.Empty;
				Y--;
				map.Grid[X, Y] = Symbols.Robot;
				Energy -= 1;
			}
			else
			{
				Console.WriteLine("Can't move to there...");
				Thread.Sleep(300);
			}
		}

		#endregion [Movement]

		#region [Interaction]

		/// <summary>
		/// Collect a <typeparamref name="Jewel" /> that is adjacent to the robot.
		/// </summary>
		/// <param name="map"></param>
		private void CollectJewel(Map map)
		{
			Jewel? jewel = null;

			if(CheckUpFor(map, Symbols.BlueJewel) || CheckUpFor(map, Symbols.GreenJewel) || CheckUpFor(map, Symbols.RedJewel))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X - 1 && jewel.Y == Y);
			}
			else if (CheckDownFor(map, Symbols.BlueJewel) || CheckDownFor(map, Symbols.GreenJewel) || CheckDownFor(map, Symbols.RedJewel))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X + 1 && jewel.Y == Y);
			}
			else if (CheckLeftFor(map, Symbols.BlueJewel) || CheckLeftFor(map, Symbols.GreenJewel) || CheckLeftFor(map, Symbols.RedJewel))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y - 1);
			}
			else if (CheckRightFor(map, Symbols.BlueJewel) || CheckRightFor(map, Symbols.GreenJewel) || CheckRightFor(map, Symbols.RedJewel))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y + 1);
			}

			if(jewel != null)
			{
				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);
			}
			
		}

		/// <summary>
		/// Interaction with a Tree in the map
		/// </summary>
		/// <param name="map"></param>
		private void InteractTree(Map map)
		{
			if(CheckUpFor(map, Symbols.Tree))
			{
				RechargeEnergy(3);
			}
			
			if(CheckDownFor(map, Symbols.Tree))
			{
				RechargeEnergy(3);
			}
			
			if(CheckLeftFor(map, Symbols.Tree))
			{
				RechargeEnergy(3);
			}
			
			if(CheckRightFor(map, Symbols.Tree))
			{
				RechargeEnergy(3);
			}
		}

        /// <summary>
        /// Recharges Robot's energy by the given <paramref name="value"/> amount.
        /// </summary>
        /// <param name="value"></param>
        private void RechargeEnergy(int value)
        {
            Energy += value;
        }

        /// <summary>
        /// Interacts with the surroundings
        /// </summary>
        /// <param name="map"></param>
        public void Interact(Map map)
        {
			CollectJewel(map);
			InteractTree(map);

			OnInteraction(EventArgs.Empty);
        }

        #endregion [Interaction]

        #region [Utils]

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

		/// <summary>
		/// Overrides ToString for showing Robot's status.
		/// </summary>
		/// <returns>Returns a string containing the Robot's status.</returns>
		public override string ToString()
		{
			return $"Energy Remaining: {Energy}";
		}

        /// <summary>
        ///	Shows in Console the values in <typeparamref name="Bag" />.
        /// </summary>
        [Obsolete(message: "Method no longer used")]
        public void PrintBag()
        {
            Bag.PrintBag();
        }

		/// <summary>
		/// Event Trigger when Robot moves
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnRobotMoved(EventArgs e)
		{
			var raiseEvent = RobotMoved;

			if(raiseEvent != null)
			{
				raiseEvent(this, e);
			}
		}

		/// <summary>
		/// Event Trigger when Robot interacts with Environment
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnInteraction(EventArgs e)
		{
			var raiseEvent = RobotInteracted;

			if(raiseEvent != null)
			{
				raiseEvent(this, e);
			}
		}

		protected virtual void OnEnergyDepleted()
		{
			var raiseEvent = EnergyDepleted;

			if(raiseEvent != null)
			{
				raiseEvent(this, EventArgs.Empty);
			}
		}

        #endregion [Utils]

    }
}
