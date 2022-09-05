using JewelCollector.Application.Interfaces;
using JewelCollector.Domain.Enums;
using JewelCollector.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Application.Services
{
    public class RobotServices : IRobotServices
    {
        public RobotServices()
        {
        }

        public void PrintBag(Map map)
        {
            Console.WriteLine($"Bag total items: {map.Robot!.Bag!.TotalItems} | Bag total value: {map.Robot!.Bag!.TotalValue}");
        }

        public bool MoveRobot(Map map, Move moveTo)
        {
            int x = map.Robot!.PosX;
            int y = map.Robot!.PosY;

            int mapHeight = map.Grid!.GetLength(0);
            int mapWidth = map.Grid!.GetLength(1);

            if (moveTo == Move.Up && CheckUpFor(map, x, y, "--"))
            {
                MoveUp(map, x, y);
                return true;
            }
            else if (moveTo == Move.Down && CheckDownFor(map, x, y, "--"))
            {
                MoveDown(map, x, y);
                return true;
            }
            else if (moveTo == Move.Left && CheckLeftFor(map, x, y, "--"))
            {
                MoveLeft(map, x, y);
                return true;
            }
            else if (moveTo == Move.Right && CheckRightFor(map, x, y, "--"))
            {
                MoveRight(map, x, y);
                return true;
            }

            return false;
        }

        public bool CollectJewel(Map map)
        {
            int x = map.Robot!.PosX;
            int y = map.Robot!.PosY;

            int mapHeight = map.Grid!.GetLength(0);
            int mapWidth = map.Grid!.GetLength(1);

            if(CheckUpFor(map, x, y, "JR") || CheckUpFor(map, x, y, "JG") || CheckUpFor(map, x, y, "JB"))
            {
                return RemoveAndAdd(map, x - 1, y);
            }
            else if(CheckDownFor(map, x, y, "JR") || CheckDownFor(map, x, y, "JG") || CheckDownFor(map, x, y, "JB"))
            {
                return RemoveAndAdd(map, x + 1, y);
            }
            else if (CheckLeftFor(map, x, y, "JR") || CheckLeftFor(map, x, y, "JG") || CheckLeftFor(map, x, y, "JB"))
            {
                return RemoveAndAdd(map, x, y - 1);
            }
            else if (CheckRightFor(map, x, y, "JR") || CheckRightFor(map, x, y, "JG") || CheckRightFor(map, x, y, "JB"))
            {
                return RemoveAndAdd(map, x, y + 1);
            }

            return false;
        }

        private void MoveUp(Map map, int x, int y)
        {
            map.Grid![x, y] = "--";
            map.Grid![x - 1, y] = "ME";
            map.Robot!.PosX -= 1;
        }

        private void MoveDown(Map map, int x, int y)
        {
            map.Grid![x, y] = "--";
            map.Grid![x + 1, y] = "ME";
            map.Robot!.PosX += 1;
        }

        private void MoveLeft(Map map, int x, int y)
        {
            map.Grid![x, y] = "--";
            map.Grid![x, y - 1] = "ME";
            map.Robot!.PosY -= 1;
        }

        private void MoveRight(Map map, int x, int y)
        {
            map.Grid![x, y] = "--";
            map.Grid![x, y + 1] = "ME";
            map.Robot!.PosY += 1;
        }

        private bool CheckUpFor(Map map, int x, int y, string str)
        {
            return x - 1 > -1 && map.Grid![x - 1, y].Equals(str);
        }

        private bool CheckDownFor(Map map, int x, int y, string str)
        {
            return x + 1 < map.Grid!.GetLength(0) && map.Grid![x + 1, y].Equals(str);
        }

        private bool CheckLeftFor(Map map, int x, int y, string str)
        {
            return y - 1 > -1 && map.Grid![x, y - 1].Equals(str);
        }

        private bool CheckRightFor(Map map, int x, int y, string str)
        {
            return y + 1 < map.Grid!.GetLength(1) && map.Grid![x, y + 1].Equals(str);
        }

        private bool RemoveAndAdd(Map map, int x, int y)
        {
            var jewel = map.Jewels!.First(j => j.PosX == x && j.PosY == y);
            map.Grid![x, y] = "--";
            map.Jewels!.Remove(jewel);
            map.Robot!.Bag!.TotalValue += jewel.Value;
            map.Robot.Bag!.TotalItems += 1;

            return true;
        }
    }
}
