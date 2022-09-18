using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
    public class Radiation : Obstacle
    {
        /// <summary>
        /// Constructor for <typeparamref name="Tree Obstacle" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Radiation(int x, int y) : base(x, y, EnumObstacle.Radiation)
        {

        }
    }
}
