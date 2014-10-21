using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This upgrade will allow the player to shoot GuidedMissiles.
    /// </summary>
    class GuidedMissileLauncher : Upgrade
    {

        /// <summary>
        /// Set up the GuidedMissileLauncher upgrade.
        /// </summary>
        /// <param name="game">The game in which we want to show this upgrade.</param>
        public GuidedMissileLauncher(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("guidedMissileIcon");
            ShootBehavior = new ShootGuidedMissiles();

        }

    }
}
