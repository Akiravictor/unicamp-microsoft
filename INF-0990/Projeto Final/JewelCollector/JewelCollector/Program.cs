namespace JewelCollector
{
    public class JewelCollector
    {

        public static void Main()
        {

            bool running = true;

            do
            {

                Console.Write("Enter the command: ");
                string command = Console.ReadLine() ?? "";

                if (command.Equals("quit"))
                {
                    running = false;
                }
                else if (command.ToLower().Equals("w"))
                {

                }
                else if (command.ToLower().Equals("s"))
                {

                }
                else if (command.ToLower().Equals("a"))
                {

                }
                else if (command.ToLower().Equals("d"))
                {

                }
                else if (command.ToLower().Equals("g"))
                {

                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }

            } while (running);
        }
    }
}