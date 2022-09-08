using JewelCollector.Board;
using JewelCollector.Bot;
using JewelCollector.Jewels;
using JewelCollector.Obstacles;

namespace JewelCollector
{
    public class JewelCollector
    {

        public static void Main()
        {
            var map = new Map(10, 10);
            var robot = new Robot(map);

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

			bool running = true;

            do
            {
                map.PrintMap();
                robot.PrintBag();

                Console.Write("Enter the command: ");
                string command = Console.ReadLine() ?? "";

                if (command.Equals("quit"))
                {
                    running = false;
                }
                else if (command.ToLower().Equals("w"))
                {
                    robot.MoveUp(map);
                }
                else if (command.ToLower().Equals("s"))
                {
                    robot.MoveDown(map);
                }
                else if (command.ToLower().Equals("a"))
                {
                    robot.MoveLeft(map);
                }
                else if (command.ToLower().Equals("d"))
                {
                    robot.MoveRight(map);
                }
                else if (command.ToLower().Equals("g"))
                {
                    robot.CollectJewel(map);
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                    Thread.Sleep(1500);
                }

                Console.Clear();

            } while (running);
        }
    }
}