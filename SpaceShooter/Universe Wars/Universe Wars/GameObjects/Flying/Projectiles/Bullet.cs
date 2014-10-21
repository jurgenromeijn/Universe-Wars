using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The bullet is a simple projectile that just moves toward the Player's crosshair.
    /// It does only 1 damage, but is quite fast.
    /// </summary>
    class Bullet : Projectile
    {

        /// <summary>
        /// Set up the Bullet.
        /// </summary>
        /// <param name="game">The game in which we want to see the Bullet.</param>
        /// <param name="startPosition">The position at which we want the Bullet to start.</param>
        /// <param name="shooter">The LivingGameObject that fired the Bullet.</param>
        public Bullet(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game, startPosition, shooter)
        {

            Texture = TextureLoader.GetTexture("bullet");
            MaxSpeed = 10;
            Damage = 1;
            FlyBehavior = new FlyInDirection(this, Game1.Player.Crosshair.Position);

        }

    }
}
