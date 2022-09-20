using JewelCollector.Board;
using JewelCollector.Bot;
using JewelCollector.Jewels;
using JewelCollector.Obstacles;
using System.Data;

namespace JewelCollector
{
    public class JewelCollector
    {
        private static Map map;
        private static Robot robot;

        public static void Main()
        {
			map = new Map(10, 10);
			robot = new Robot(map);

            map.LevelCleared += Map_LevelCleared;
            map.GameCleared += Map_GameCleared;

            robot.RobotMoved += Robot_RobotMoved;
            robot.RobotInteracted += Robot_RobotMoved;
            robot.EnergyDepleted += Robot_EnergyDepleted;

			bool running = true;

            PrintMap();

            do
            {
                
                var command = Console.ReadKey(true);

                if (command.Key == ConsoleKey.Escape)
                {
                    running = false;
                }
                else if (command.KeyChar.ToString().ToUpper().Equals("W"))
                {
                    robot.Move(map, EnumMove.Up);
                }
                else if (command.KeyChar.ToString().ToUpper().Equals("S"))
                {
                    robot.Move(map, EnumMove.Down);
                }
                else if (command.KeyChar.ToString().ToUpper().Equals("A"))
                {
                    robot.Move(map, EnumMove.Left);
                }
                else if (command.KeyChar.ToString().ToUpper().Equals("D"))
                {
                    robot.Move(map, EnumMove.Right);
                }
                else if (command.KeyChar.ToString().ToUpper().Equals("G"))
                {
                    robot.Interact(map);
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                    Thread.Sleep(1500);
                }

            } while (running);
        }

        private static void Map_GameCleared(object? sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Congratulations you Cleared all levels!");
            Console.WriteLine("Press ENTER to restart the game.");

            ConsoleKeyInfo cmd;

            do
            {
                cmd = Console.ReadKey();
            } while (cmd.Key != ConsoleKey.Enter);

            map.ResetLevel();
            map.GenerateMap();

            robot.ResetRobot(map);

            Console.Clear();
            PrintMap();
        }

        private static void Robot_EnergyDepleted(object? sender, EventArgs e)
        {
            Console.WriteLine("Game Over! Press ENTER to reset.");

            ConsoleKeyInfo cmd;
            do
            {
				cmd = Console.ReadKey(true);
			}
            while (cmd.Key != ConsoleKey.Enter);

            map.ResetLevel();
            map.GenerateMap();

            robot.ResetRobot(map);

			Console.Clear();
			PrintMap();
		}

        private static void Map_LevelCleared(object? sender, EventArgs e)
        {
            Console.WriteLine("All Jewels collected! Press ENTER to next level.");
			ConsoleKeyInfo cmd;
			do
			{
				cmd = Console.ReadKey(true);
			}
			while (cmd.Key != ConsoleKey.Enter);

			map.LevelUp();
            map.GenerateMap();

            robot.ResetRobot(map);

            Console.Clear();
            PrintMap();
        }

        /// <summary>
        /// Event Handling when Robot Moves or Interacts with Environment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Robot_RobotMoved(object? sender, EventArgs e)
        {
			Console.Clear();
			PrintMap();
		}

        /// <summary>
        /// Prints on Console the Map and Status
        /// </summary>
        private static void PrintMap()
        {
            Console.WriteLine($"Level: {map.Level}");
			Console.WriteLine(map.ToString());
			Console.WriteLine(robot.Bag.ToString());
			Console.WriteLine(robot.ToString());
            Console.WriteLine($"Jewels Remaining: {map.Jewels.Count}");

			Console.WriteLine("Commands:");
			Console.WriteLine("W - Up | A - Left | S - Down | D - Right | G - Use/Collect | Esc - Quit");

#if DEBUG
            Console.WriteLine();
            Console.WriteLine($"Map Height: {map.Height} Width: {map.Width}");
            Console.WriteLine($"Robot: [{robot.X},{robot.Y}]");
            Console.Write("Jewel List: ");
            foreach(var j in map.Jewels)
            {
                Console.Write($"[{j.X},{j.Y}] ");
            }
			Console.WriteLine();
			Console.Write("Obstacles List: ");
			foreach (var j in map.Obstacles)
			{
				Console.Write($"[{j.X},{j.Y}] ");
			}
			Console.WriteLine();
#endif
        }
	}
}