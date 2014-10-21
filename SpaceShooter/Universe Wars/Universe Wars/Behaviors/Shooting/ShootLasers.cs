using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{
    /// <summary>
    /// Gives LivingGameObjects the opportuninity to shoot laserbeams at a certain interval.
    /// </summary>
    class ShootLasers : IShootBehavior
    {

        private float _fireInterval = 0.5f;
        private DateTime _lastShotTime;

        /// <summary>
        /// Initialize the object.
        /// </summary>
        public ShootLasers()
        {

            _lastShotTime = new DateTime();

        }

        /// <summary>
        /// Fire a laser if the last shot was after the interfal.
        /// </summary>
        /// <param name="shooter">The LivingGameObject that wants to shoot the laserbeam.</param>
        public void Shoot(LivingGameObject shooter)
        {

            TimeSpan timeSinceLastShot = DateTime.Now - _lastShotTime;

            if (timeSinceLastShot.TotalSeconds >= _fireInterval)
            {

                LaserBeam laser = new LaserBeam(shooter.Game, shooter.Position, shooter);

                _lastShotTime = DateTime.Now;

            }

        }

    }

}
