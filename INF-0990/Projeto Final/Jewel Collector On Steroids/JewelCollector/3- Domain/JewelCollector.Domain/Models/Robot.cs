using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Domain.Models
{
    public class Robot
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Bag? Bag { get; set; }

    }
}
