using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot.Exceptions
{
    public class CantMoveRobotException : Exception
    {
        public CantMoveRobotException(string msg) : base(msg)
        {

        }
    }
}
