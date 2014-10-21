using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// This behavior adds absolutly nothing.
    /// </summary>
    class DieNothingHappens : IDieBehavior
    {
        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="dieingGameObject">The livinggameobject that wants nothing to happen</param>
        public void Die(LivingGameObject dieingGameObject)
        {
            // Do absolutely nothing
        }
    }
}
