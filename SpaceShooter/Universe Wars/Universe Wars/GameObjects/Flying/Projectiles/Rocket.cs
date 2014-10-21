using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The bullet is a simple fire and forget projectile that just moves toward the Player's crosshair.
    /// It does 3 damage, but is rather slow.
    /// </summary>
    class Rocket : Projectile
    {

        /// <summary>
        /// Set up the Rocket.
        /// </summary>
        /// <param name="game">The game in which we want to see the Rocket.</param>
        /// <param name="startPosition">The position at which we want the Rocket to start.</param>
        /// <param name="shooter">The LivingGameObject that fired the Rocket.</param>
        public Rocket(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game, startPosition, shooter)
        {

            Texture = TextureLoader.GetTexture("rocket");
            Damage = 3;
            MaxSpeed = 5;
            FlyBehavior = new FlyInDirection(this, Game1.Player.Crosshair.Position);

        }

    }
}
