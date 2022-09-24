using JewelCollector.Board;
using JewelCollector.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Interfaces
{
    public interface IInteraction
    {
        void Move(Map map, EnumMove moveTo);
        void Interact(Map map);
    }
}
