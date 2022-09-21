using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot.Exceptions
{
	public class NothingToInteractException : Exception
	{
		public NothingToInteractException(string msg) : base(msg)
		{

		}
	}
}
