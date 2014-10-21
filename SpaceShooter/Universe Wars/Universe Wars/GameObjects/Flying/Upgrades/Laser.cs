using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This upgrade will allow the player to shoot Lasers.
    /// </summary>
    class Laser : Upgrade
    {

        /// <summary>
        /// Set up the Laser upgrade.
        /// </summary>
        /// <param name="game">The game in which we want to show this upgrade.</param>
        public Laser(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("laserIcon");
            ShootBehavior = new ShootLasers();

        }

    }
}
