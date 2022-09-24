using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Interfaces
{
	public interface IRechargeable
	{
		/// <summary>
		/// Interface method for recharging Energy.
		/// </summary>
		/// <returns></returns>
		public int RechargeEnergy();
	}
}
