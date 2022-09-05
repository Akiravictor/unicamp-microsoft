using JewelCollector.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Domain.Models
{
    public class Map
    {
        public string[,]? Grid { get; set; }
        public Robot? Robot { get; set; }
        public List<Jewel>? Jewels { get; set; }
        public List<Obstacle>? Obstacles { get; set; }

    }
}
