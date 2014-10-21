using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The bomb gets dropped and then scrolls slowly to the right. It does 2 damage.
    /// </summary>
    class Bomb : Projectile
    {

        /// <summary>
        /// Set up the Bomb.
        /// </summary>
        /// <param name="game">The game in which we want to see the bomb.</param>
        /// <param name="startPosition">The position at which we want the bomb to start.</param>
        /// <param name="shooter">The LivingGameObject that fired the bomb.</param>
        public Bomb(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game, startPosition, shooter)
        {

            Texture = TextureLoader.GetTexture("bomb");
            FlyBehavior = new FlyScrollSpeed(this);
            Damage = 2;

        }

    }
}
