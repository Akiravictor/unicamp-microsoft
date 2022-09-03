using JewelCollector.Application.Interfaces;
using JewelCollector.Domain.Abstracts;
using JewelCollector.Domain.Enums;
using JewelCollector.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Application.Services
{
    public class MapServices : IMapServices
    {
        private Map? _map;
        private readonly IRobotServices _robotServices;
        public MapServices(IRobotServices robotServices)
        {
            _robotServices = robotServices ?? throw new ArgumentNullException(nameof(IRobotServices));
        }

        public void CreateEmptyMap(int height, int length)
        {
            _map =  new Map
            {
                Grid = new string[height, length],
                Jewels = new List<Jewel>(),
                Obstacles = new List<Obstacle>(),
                Robot = new Robot
                {
                    PosX = 0,
                    PosY = 0,
                    Bag = new Bag
                    {
                        TotalItems = 0,
                        TotalValue = 0
                    }
                }
            };

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    _map.Grid[i, j] = "--";
                }
            }

            _map.Grid[0, 0] = "ME";
        }

        public void AddJewel(int X, int Y, Color color)
        {
            if (color == Color.Red)
            {
                _map!.Jewels!.Add(new Red { PosX = X, PosY = Y });
                _map.Grid![X, Y] = "JR";
            }
            else if(color == Color.Green)
            {
                _map!.Jewels!.Add(new Green { PosX = X, PosY = Y });
                _map.Grid![X, Y] = "JG";
            }
            else if(color == Color.Blue)
            {
                _map!.Jewels!.Add(new Blue { PosX= X, PosY = Y });
                _map.Grid![X, Y] = "JB";
            }
        }

        public void AddWater(int X, int Y)
        {
            _map!.Obstacles!.Add(new Water { PosX = X, PosY = Y });
            _map.Grid![X, Y] = "##";
        }

        public void AddTree(int X, int Y)
        {
            _map!.Obstacles!.Add(new Tree { PosX = X, PosY = Y });
            _map.Grid![X, Y] = "$$";
        }

        public void PrintGrid()
        {
            var grid = _map!.Grid ?? throw new Exception("There is no Map!");

            var height = grid.GetLength(0);
            var width = grid.GetLength(1);

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write($"{grid[i,j]}  ");
                }
                Console.WriteLine();
            }
        }

        public int GetJewels()
        {
            return _map!.Jewels!.Count;
        }

        public bool MoveRobot(Move moveTo)
        {
            return _robotServices.MoveRobot(_map!, moveTo);
        }

        public bool Collect()
        {
            return _robotServices.CollectJewel(_map!);
        }

        public void ShowBag()
        {
            _robotServices.PrintBag(_map!);
        }
    }
}
