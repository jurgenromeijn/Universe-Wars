using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This upgrade will allow the player to shoot Rockets.
    /// </summary>
    class RocketLauncher : Upgrade
    {

        /// <summary>
        /// Set up the RocketLauncher upgrade.
        /// </summary>
        /// <param name="game">The game in which we want to show this upgrade.</param>
        public RocketLauncher(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("rocketIcon");
            ShootBehavior = new ShootRockets();

        }

    }
}
