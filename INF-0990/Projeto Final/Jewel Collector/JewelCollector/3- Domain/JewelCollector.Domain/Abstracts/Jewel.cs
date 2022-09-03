using JewelCollector.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Domain.Abstracts
{
    public abstract class Jewel
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Value { get; set; }
    }
}
