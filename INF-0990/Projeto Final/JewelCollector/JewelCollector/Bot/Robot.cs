using JewelCollector.Board;
using JewelCollector.Bot.Exceptions;
using JewelCollector.Consts;
using JewelCollector.Interfaces;
using JewelCollector.Jewels;
using JewelCollector.Obstacles;
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
		public event EventHandler? RobotMoved;

		/// <summary>
		/// Robot's Interaction event
		/// </summary>
		public event EventHandler? RobotInteracted;

		/// <summary>
		/// Event for Energy depleted
		/// </summary>
		public event EventHandler? EnergyDepleted;

        /// <summary>
        /// Constructor for <typeparamref name="Robot" />
		/// Sets the robot in position (0,0) in the Grid.
        /// </summary>
        /// <param name="map"></param>
        public Robot(Map map)
		{
			Bag = new Bag();
			map.Grid[0, 0] = Symbols.Robot;
			Energy = EnergyAmount.StartEnergy;

		}

		/// <summary>
		/// Resets Robot's properties
		/// </summary>
		/// <param name="map"></param>
		public void ResetRobot(Map map)
		{
			Bag.ResetBag();
			map.Grid[0, 0] = Symbols.Robot;

			X = 0;
			Y = 0;
			Energy = EnergyAmount.StartEnergy;

		}

		#region [Movement]

		/// <summary>
		/// Move robot accordingly to <paramref name="moveTo"/>.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="moveTo"></param>
		/// <exception cref="CantMoveRobotException"></exception>
		public void Move(Map map, EnumMove moveTo)
		{
			try
			{
				if (Energy > 0)
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
				}
				else
				{
					Console.WriteLine("Not more Energy available...");

					OnEnergyDepleted();
				}
			}
			catch(Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Moves the robot 1 position Up in the Grid.
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="CantMoveRobotException"></exception>
		private void MoveUp(Map map)
		{
			if(CheckUpFor(map, Symbols.Empty) || CheckUpFor(map, Symbols.Radiation))
			{
				X--;
				ConsumeEnergy(EnergyAmount.MovementEnergy);

                if (CheckForRadiation(map))
                {
                    RadiationDamage(map);
                }

                OnRobotMoved(EventArgs.Empty);
			}
			else
			{
				throw new CantMoveRobotException($"Can't move robot to position [{X -1},{Y}]");
			}
		}

		/// <summary>
		/// Moves the robot 1 position Down in the Grid.
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="CantMoveRobotException"></exception>
		private void MoveDown(Map map)
		{
			if(CheckDownFor(map, Symbols.Empty) || CheckDownFor(map, Symbols.Radiation))
			{
				X++;
				ConsumeEnergy(EnergyAmount.MovementEnergy);

                if (CheckForRadiation(map))
                {
                    RadiationDamage(map);
                }

                OnRobotMoved(EventArgs.Empty);
			}
			else
			{
				throw new CantMoveRobotException($"Can't move robot to position [{X + 1},{Y}]");
			}
		}

		/// <summary>
		/// Moves the robot 1 position Right in the Grid.
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="CantMoveRobotException"></exception>
		private void MoveRight(Map map)
		{
			if(CheckRightFor(map, Symbols.Empty) || CheckRightFor(map, Symbols.Radiation))
			{
				Y++;
				ConsumeEnergy(EnergyAmount.MovementEnergy);

                if (CheckForRadiation(map))
                {
                    RadiationDamage(map);
                }

                OnRobotMoved(EventArgs.Empty);
			}
			else
			{
				throw new CantMoveRobotException($"Can't move robot to position [{X},{Y + 1}]");
			}
		}

		/// <summary>
		/// Moves the robot 1 position Left in the Grid.
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="CantMoveRobotException"></exception>
		private void MoveLeft(Map map)
		{
			if(CheckLeftFor(map, Symbols.Empty) || CheckLeftFor(map, Symbols.Radiation))
			{
				Y--;
				ConsumeEnergy(EnergyAmount.MovementEnergy);

				if (CheckForRadiation(map))
				{
					RadiationDamage(map);
				}

				OnRobotMoved(EventArgs.Empty);
			}
			else
			{
				throw new CantMoveRobotException($"Can't move robot to position [{X},{Y - 1}]");
			}
		}

		#endregion [Movement]

		#region [Interaction]

		/// <summary>
		/// Collect a <typeparamref name="Jewel" /> that is adjacent to the robot.
		/// </summary>
		/// <param name="map"></param>
		private bool CollectJewel(Map map)
		{
			Jewel? jewel = null;

			if (JewelUp(map))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X - 1 && jewel.Y == Y);
			}
			else if (JewelDown(map))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X + 1 && jewel.Y == Y);
			}
			else if (JewelLeft(map))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y - 1);
			}
			else if (JewelRight(map))
			{
				jewel = map.Jewels.First(jewel => jewel.X == X && jewel.Y == Y + 1);
			}

			if (jewel != null)
			{
				if (jewel.GetType() == typeof(Blue))
				{
					var blue = (Blue)jewel;
					RechargeEnergy(blue.RechargeEnergy());
				}

				Bag.AddItem(jewel.Value);
				map.RemoveJewel(jewel);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Interaction with a Tree in the map
		/// </summary>
		/// <param name="map"></param>
		private bool InteractTree(Map map)
		{
			if(CheckForTree(map))
			{
				var trees = GetTrees(map);

				foreach(Tree tree in trees)
				{
					RechargeEnergy(tree.RechargeEnergy());					
				}

				return true;
			}

			return false;
		}

        /// <summary>
		/// Interacts with the surroundings
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="NothingToInteractException"></exception>
        public void Interact(Map map)
        {
			var hasInteracted = CollectJewel(map) || InteractTree(map);

			if (CheckForRadiation(map) && hasInteracted)
			{
				RadiationDamage(map);
            }

			if (hasInteracted)
			{
				OnInteraction(EventArgs.Empty);
			}
			else
			{
				throw new NothingToInteractException($"Nothing to interact with in the surroundings.");
			}

        }

		#endregion [Interaction]

        /// <summary>
        /// Recharges Robot's energy by the given <paramref name="value"/> amount.
        /// </summary>
        /// <param name="value"></param>
        private void RechargeEnergy(int value)
        {
            Energy += value;
        }

		/// <summary>
		/// Consumes Robot's energy by the given <paramref name="value"/> amount.
		/// </summary>
		/// <param name="value"></param>
		private void ConsumeEnergy(int value)
		{
			Energy -= value;
		}

		/// <summary>
		/// Check if there is a Radiation near Robot's position.
		/// </summary>
		/// <param name="map"></param>
		/// <returns>Returns <paramref name="True"/> if there is a Radiation nearby. </returns>
        private bool CheckForRadiation(Map map)
		{
			return CheckUpFor(map, Symbols.Radiation) || CheckDownFor(map, Symbols.Radiation) || CheckLeftFor(map, Symbols.Radiation) || CheckRightFor(map, Symbols.Radiation);
		}

		/// <summary>
		/// Get all Radiation nearby Robot's position.
		/// </summary>
		/// <param name="map"></param>
		/// <returns>Returns a <typeparamref name="List" /> of <typeparamref name="Obstacle" /> with all Radiation nearby.</returns>
		private List<Obstacle> GetRadiation(Map map)
		{
			return map.Obstacles.FindAll(o => o.X <= X + 1 && o.X >= X - 1 && o.Y <= Y + 1 && o.Y >= Y - 1 && o.Type == EnumObstacle.Radiation);
        }

		/// <summary>
		/// Applies damage for all Radiation found nearby.
		/// </summary>
		/// <param name="map"></param>
		private void RadiationDamage(Map map)
		{
            var radiations = GetRadiation(map);

            foreach (Radiation radiation in radiations)
            {
                if (radiation.X == X && radiation.Y == Y)
                {
                    ConsumeEnergy(radiation.StepDamageSource());
                }
                else
                {
                    ConsumeEnergy(radiation.NearDamageSource());

                }
            }
        }

        /// <summary>
        /// Check if there is a Tree near Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns <paramref name="True"/> if there is a Tree nearby. </returns>
        private bool CheckForTree(Map map)
		{
			return CheckUpFor(map, Symbols.Tree) || CheckDownFor(map, Symbols.Tree) || CheckLeftFor(map, Symbols.Tree) || CheckRightFor(map, Symbols.Tree);
		}

        /// <summary>
        /// Get all Radiation nearby Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns a <typeparamref name="List" /> of <typeparamref name="Obstacle" /> with all Radiation nearby.</returns>
        private List<Obstacle> GetTrees(Map map)
		{
			return map.Obstacles.FindAll(o => o.X <= X + 1 && o.X >= X - 1 && o.Y <= Y + 1 && o.Y >= Y - 1 && o.Type == EnumObstacle.Tree);
		}

        /// <summary>
        /// Check if there is a Jewel Above Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns <paramref name="True"/> if there is any Jewel nearby. </returns>
        private bool JewelUp(Map map)
		{
			return CheckUpFor(map, Symbols.BlueJewel) || CheckUpFor(map, Symbols.GreenJewel) || CheckUpFor(map, Symbols.RedJewel);
		}

        /// <summary>
        /// Check if there is a Jewel Below Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns <paramref name="True"/> if there is any Jewel nearby. </returns>
        private bool JewelDown(Map map)
		{
			return CheckDownFor(map, Symbols.BlueJewel) || CheckDownFor(map, Symbols.GreenJewel) || CheckDownFor(map, Symbols.RedJewel);
		}

        /// <summary>
        /// Check if there is a Jewel to the Left of Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns <paramref name="True"/> if there is any Jewel nearby. </returns>
        private bool JewelLeft(Map map)
		{
			return CheckLeftFor(map, Symbols.BlueJewel) || CheckLeftFor(map, Symbols.GreenJewel) || CheckLeftFor(map, Symbols.RedJewel);
		}

        /// <summary>
        /// Check if there is a Jewel to the Right of Robot's position.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Returns <paramref name="True"/> if there is any Jewel nearby. </returns>
        private bool JewelRight(Map map)
		{
			return CheckRightFor(map, Symbols.BlueJewel) || CheckRightFor(map, Symbols.GreenJewel) || CheckRightFor(map, Symbols.RedJewel);
		}


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
        public void PrintBag()
        {
            Bag.PrintBag();
        }

        #endregion [Utils]

        #region [Events]

        /// <summary>
        /// Event Trigger when Robot moves.
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
		/// Event Trigger when Robot interacts with Environment.
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

        /// <summary>
        /// Event Trigger when Robot's Energy is depleted.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnergyDepleted()
		{
			var raiseEvent = EnergyDepleted;

			if(raiseEvent != null)
			{
				raiseEvent(this, EventArgs.Empty);
			}
		}

		#endregion {events]
	}
}
