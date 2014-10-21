using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// This Behavior is able to drop bombs.
    /// </summary>
    class ShootBomb : IShootBehavior
    {

        /// <summary>
        /// Drop a bomb.
        /// </summary>
        /// <param name="shooter">The LivingGameObject that wants to drop the bomb</param>
        public void Shoot(LivingGameObject shooter)
        {

            Bomb bomb = new Bomb(shooter.Game, shooter.Position, shooter);

        }

    }
}
