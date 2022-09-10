using JewelCollector.Domain.Enums;
using JewelCollector.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Application.Interfaces
{
    public interface IRobotServices
    {
        void PrintBag(Map map);
        bool MoveRobot(Map map, Move moveTo);
        bool CollectJewel(Map map);
    }
}
