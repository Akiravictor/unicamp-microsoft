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
        /// <summary>
        /// Interface method for Moving.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="moveTo"></param>
        void Move(Map map, EnumMove moveTo);

        /// <summary>
        /// Interface method for Interacting with Map.
        /// </summary>
        /// <param name="map"></param>
        void Interact(Map map);
    }
}
