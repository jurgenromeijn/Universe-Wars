using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{
    /// <summary>
    /// This class gives LivingGameObject the posibility to shoot bullets at a certain interval.
    /// </summary>
    class ShootBullets : IShootBehavior
    {

        private float _fireInterval = 0.2f;
        private DateTime _lastShotTime;

        /// <summary>
        /// Initialize this object and set up a time for the last fired shot.
        /// </summary>
        public ShootBullets()
        {

            _lastShotTime = new DateTime();

        }

        /// <summary>
        /// Shoot a bullet if were not exceeding the maximum firerate.
        /// </summary>
        /// <param name="shooter">The LivingGameObject that wants to shoot the bullet</param>
        public void Shoot(LivingGameObject shooter)
        {

            TimeSpan timeSinceLastShot = DateTime.Now - _lastShotTime;

            if (timeSinceLastShot.TotalSeconds >= _fireInterval)
            {

                Bullet bullet = new Bullet(shooter.Game, shooter.Position, shooter);

                _lastShotTime = DateTime.Now;

            }

        }

    }

}
