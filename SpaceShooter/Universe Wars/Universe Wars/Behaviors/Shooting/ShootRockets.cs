using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Gives LivingGameObject the posibility to shoot Rockets at a certain interval.
    /// </summary>
    class ShootRockets : IShootBehavior
    {

        private float _fireInterval = 1;
        private DateTime _lastShotTime;

        /// <summary>
        /// Initialize the object and set a new lastShotTime.
        /// </summary>
        public ShootRockets()
        {

            _lastShotTime = new DateTime();

        }

        /// <summary>
        /// If it is past the interval shoot a laser.
        /// </summary>
        /// <param name="shooter">The LivingGameObjec that wants to shoot the rocket.</param>
        public void Shoot(LivingGameObject shooter)
        {

            TimeSpan timeSinceLastShot = DateTime.Now - _lastShotTime;

            if (timeSinceLastShot.TotalSeconds >= _fireInterval)
            {

                Rocket rocket = new Rocket(shooter.Game, shooter.Position, shooter);

                _lastShotTime = DateTime.Now;

            }

        }

    }
}
