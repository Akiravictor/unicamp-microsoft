using JewelCollector.Domain.Enums;
using JewelCollector.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Application.Interfaces
{
    public interface IMapServices
    {
        void CreateEmptyMap(int height, int length);
        void AddJewel(int X, int Y, Color color);
        void AddWater(int X, int Y);
        void AddTree(int X, int Y);
        void PrintGrid();
        int GetJewels();
        bool MoveRobot(Move moveTo);
        bool Collect();
        void ShowBag();
    }
}
