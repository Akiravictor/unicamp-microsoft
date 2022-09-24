using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Interfaces
{
    public interface IDamageable
    {
        /// <summary>
        /// Interface method for returning the amount of damage taken when near source of damage.
        /// </summary>
        /// <returns>An <typeparamref name="int" /> representing the amount of damage taken. </returns>
        public int NearDamageSource();

        /// <summary>
        /// Interface method for returning the amount of damage taken when neastepping on source of damage.
        /// </summary>
        /// <returns>An <typeparamref name="int" /> representing the amount of damage taken. </returns>
        public int StepDamageSource();
    }
}
