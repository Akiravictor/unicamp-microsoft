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

			map.AddJewel(new Red(1,9));
			map.AddJewel(new Red(8,8));
			map.AddJewel(new Green(9,1));
			map.AddJewel(new Green(7,6));
			map.AddJewel(new Blue(3,4));
			map.AddJewel(new Blue(2,1));

            map.AddObstacle(new Water(5,0));
			map.AddObstacle(new Water(5,1));
			map.AddObstacle(new Water(5,2));
			map.AddObstacle(new Water(5,3));
			map.AddObstacle(new Water(5,4));
			map.AddObstacle(new Water(5,5));
			map.AddObstacle(new Water(5,6));
			map.AddObstacle(new Tree(5,9));
			map.AddObstacle(new Tree(3,9));
			map.AddObstacle(new Tree(8,3));
			map.AddObstacle(new Tree(2,5));
			map.AddObstacle(new Tree(1,4));

            robot.RobotMoved += Robot_RobotMoved;
            robot.RobotInteracted += Robot_RobotMoved;

			bool running = true;

            PrintMap();

            do
            {
                
                //string command = Console.ReadLine() ?? "";

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
			Console.WriteLine(map.ToString());
			Console.WriteLine(robot.Bag.ToString());
			Console.WriteLine(robot.ToString());

			Console.WriteLine("Commands:");
			Console.WriteLine("W - Up | A - Left | S - Down | D - Right | G - Use/Collect | Esc - Quit");
		}
    }
}