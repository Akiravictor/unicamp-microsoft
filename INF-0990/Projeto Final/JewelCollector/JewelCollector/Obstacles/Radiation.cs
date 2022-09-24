using JewelCollector.Consts;
using JewelCollector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Obstacles
{
    public class Radiation : Obstacle, IDamageable
    {
        /// <summary>
        /// Constructor for <typeparamref name="Tree Obstacle" />.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Radiation(int x, int y) : base(x, y, EnumObstacle.Radiation)
        {

        }

        /// <summary>
        /// Return the amount of damage when near damage source.
        /// </summary>
        /// <returns>An <typeparamref name="int" /> representing the amount of damage taken. </returns>
        public int NearDamageSource()
        {
            return EnergyAmount.NearRadiation;
        }

        /// <summary>
        /// Return the amount of damage when stepping on damage source.
        /// </summary>
        /// <returns>An <typeparamref name="int" /> representing the amount of damage taken. </returns>
        public int StepDamageSource()
        {
            return EnergyAmount.StepRadiation;
        }
    }
}
