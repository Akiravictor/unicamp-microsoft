using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Bot.Exceptions
{
	public class NothingToInteractException : Exception
	{
        /// <summary>
        /// Constructor for <typeparamref name="NothingToInteractException" />.
        /// </summary>
        /// <param name="msg"></param>
        public NothingToInteractException(string msg) : base(msg)
		{

		}
	}
}
