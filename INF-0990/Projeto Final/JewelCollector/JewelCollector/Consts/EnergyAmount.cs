using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Consts
{
	/// <summary>
	/// Contants for Energy.
	/// </summary>
	public static class EnergyAmount
	{
		/// <summary>
		/// Base amount of Robot's starting Energy.
		/// </summary>
		public const int StartEnergy = 5;

        /// <summary>
        /// Base amount of Robot's Energy consumption when moving.
        /// </summary>
        public const int MovementEnergy = 1;

        /// <summary>
        /// Base amount of Energy provided by a Blue Jewel.
        /// </summary>
        public const int BlueEnergy = 5;

        /// <summary>
        /// Base amount of Energy provided by a Tree.
        /// </summary>
        public const int TreeEnergy = 3;

        /// <summary>
        /// Base amount of Energy removed when near a Radiation source.
        /// </summary>
		public const int NearRadiation = 10;

        /// <summary>
        /// Base amount of Energy removed when stepping on a Radiation source.
        /// </summary>
		public const int StepRadiation = 30;
	}
}
