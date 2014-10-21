using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Take up memory and shoot nothing.
    /// </summary>
    class ShootNothing : IShootBehavior
    {

        public void Shoot(LivingGameObject shooter)
        {
            //done, did absolutely nothing
        }
    }
}
