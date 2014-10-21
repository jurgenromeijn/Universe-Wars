using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The bullet is a simple projectile that keeps on following the player's crosshair until it hits something
    /// It does a lot of damage, 4, which is enought to kill any enemy with 1 hit. It has also half the speed of a bullet.
    /// </summary>
    class GuidedMissile : Projectile
    {

        public GuidedMissile(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game, startPosition, shooter)
        {

            /// <summary>
            /// Set up the GuidedMissile.
            /// </summary>
            /// <param name="game">The game in which we want to see the GuidedMissile.</param>
            /// <param name="startPosition">The position at which we want the GuidedMissile to start.</param>
            /// <param name="shooter">The LivingGameObject that fired the GuidedMissile.</param>
            Texture = TextureLoader.GetTexture("rocket");
            MaxSpeed = 5;
            Damage = 4;
            FlyBehavior = new FlyTowardsObject(this, Game1.Player.Crosshair);

        }

    }
}
