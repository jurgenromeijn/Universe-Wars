using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// This class lets LivingGameObjects fire guided missile at a certain interval.
    /// </summary>
    class ShootGuidedMissiles : IShootBehavior
    {

        private float _fireInterval = 2;
        private DateTime _lastShotTime;

        /// <summary>
        /// Initialize the object and set a new lastShotTime.
        /// </summary>
        public ShootGuidedMissiles()
        {

            _lastShotTime = new DateTime();

        }

        /// <summary>
        /// Fire a guided missile if the time since that last shot is longer then the interval.
        /// </summary>
        /// <param name="shooter">The LivingGameObject that is trying to shoot the Guided Missile</param>
        public void Shoot(LivingGameObject shooter)
        {

            TimeSpan timeSinceLastShot = DateTime.Now - _lastShotTime;

            if (timeSinceLastShot.TotalSeconds >= _fireInterval)
            {

                GuidedMissile rocket = new GuidedMissile(shooter.Game, shooter.Position, shooter);

                _lastShotTime = DateTime.Now;

            }

        }

    }

}