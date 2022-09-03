using JewelCollector.Application.Interfaces;
using JewelCollector.Application.Services;
using JewelCollector.Domain.Enums;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Service
{
    public class Worker : IHostedService
    {
        private readonly IMapServices _mapServices;

        public Worker(IMapServices mapServices)
        {
            _mapServices = mapServices ?? throw new ArgumentNullException(nameof(IMapServices));

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            bool running = true;
            string? command = "";

            _mapServices.CreateEmptyMap(10, 10);
            _mapServices.AddJewel(1, 9, Color.Red);
            _mapServices.AddJewel(8, 8, Color.Red);
            _mapServices.AddJewel(9, 1, Color.Green);
            _mapServices.AddJewel(7, 6, Color.Green);
            _mapServices.AddJewel(3, 4, Color.Blue);
            _mapServices.AddJewel(2, 1, Color.Blue);

            _mapServices.AddWater(5, 0);
            _mapServices.AddWater(5, 1);
            _mapServices.AddWater(5, 2);
            _mapServices.AddWater(5, 3);
            _mapServices.AddWater(5, 4);
            _mapServices.AddWater(5, 5);
            _mapServices.AddWater(5, 6);

            _mapServices.AddTree(5, 9);
            _mapServices.AddTree(3, 9);
            _mapServices.AddTree(8, 3);
            _mapServices.AddTree(2, 5);
            _mapServices.AddTree(1, 4);

            do
            {
                _mapServices.PrintGrid();
                _mapServices.ShowBag();
                Console.Write("Enter the command: ");

                command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    PrintMessage("Invalid Command...");
                }
                else if (command.ToLower().Equals("quit"))
                {
                    running = false;
                }
                else if (command.ToLower().Equals("w"))
                {
                    if (!_mapServices.MoveRobot(Move.Up))
                    {
                        PrintMessage("Cannot move there!");
                    }
                }
                else if (command.ToLower().Equals("s"))
                {
                    if (!_mapServices.MoveRobot(Move.Down))
                    {
                        PrintMessage("Cannot move there!");
                    }
                }
                else if (command.ToLower().Equals("a"))
                {
                    if (!_mapServices.MoveRobot(Move.Left))
                    {
                        PrintMessage("Cannot move there!");
                    }
                }
                else if (command.ToLower().Equals("d"))
                {
                    if (!_mapServices.MoveRobot(Move.Right))
                    {
                        PrintMessage("Cannot move there!");
                    }
                }
                else if (command.ToLower().Equals("g"))
                {
                    if (_mapServices.Collect())
                    {
                        PrintMessage("Item Collected!");
                    }
                    else
                    {
                        PrintMessage("Nothing to collect.");
                    }
                }
                else
                {
                    PrintMessage("Invalid Command...");
                }

                if(_mapServices.GetJewels() == 0)
                {
                    Console.WriteLine("You collected ALL jewels!");
                    Console.WriteLine("Press ENTER to exit.");
                    Console.ReadLine();
                    running = false;
                }

                Console.Clear();
                command = "";

            } while (running);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
            Thread.Sleep(1000);
        }
    }
}
