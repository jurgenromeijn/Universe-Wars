using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Classes that implement this interface must give LivingGameObject some way to fire projectiles.
    /// </summary>
    interface IShootBehavior
    {

        void Shoot(LivingGameObject shooter);

    }
}
