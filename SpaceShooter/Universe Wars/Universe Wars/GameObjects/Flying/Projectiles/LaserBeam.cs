using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// The Laser is a light based projectile that travels at the speed of light. It does twice the damage of a bullet.
    /// It is only active for one screen, after that it will fade out. 
    /// </summary>
    class LaserBeam : Projectile
    {

        private bool _canBeDeactivated = false;
        private IFadeBehavior _fadeBehavior;

        public override Texture2D Texture
        {
            set
            {
                base.Texture = value;

                Vector2 tempOrigin = Origin;

                tempOrigin.X = 0; //reset horizontal origin to 0 to make sure the laser always points out of the ship

                Origin = tempOrigin;

            }

        }

        /// <summary>
        /// Set up the LaserBeam and make it at least the diagonal screen size.
        /// </summary>
        /// <param name="game">The game in which we want to see the LaserBeam.</param>
        /// <param name="startPosition">The position at which we want the LaserBeam to start.</param>
        /// <param name="shooter">The LivingGameObject that fired the LaserBeam.</param>
        public LaserBeam(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game, startPosition, shooter)
        {

            Texture = TextureLoader.GetTexture("laser");
            Damage = 2;
            FlyBehavior = new FlyInDirection(this, Game1.Player.Crosshair.Position);
            _fadeBehavior = new FadeOutExponentialFast();

            // pythagoras to get the diagonal screen size, this to make sure the laserbeam is always longer than the screen
            Width = (int)Math.Sqrt(Math.Pow(Game1.Graphics.PreferredBackBufferWidth, 2) + Math.Pow(Game1.Graphics.PreferredBackBufferHeight, 2));
            Height = 2;


        }

        /// <summary>
        /// Adjusts the color of the laser so it will fade out. 
        /// Also will make sure the laser can be removed from the projectiles list next update loop.
        /// Once its red color get below 0, remove it because it is invisible anyway.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            // make sure the laser is in the projectile list for at least one update round so it can damage stuff, after that it has become inactive and will fade out and remove itself.
            if (_canBeDeactivated)
            {

                State = ProjectileState.Inactive;

            }

            _fadeBehavior.Fade(this);

            if (Color.R < 1)
            {
                Game1.ActiveLevel.Projectiles.Remove(this);
                Dispose();
            }

            _canBeDeactivated = true;

            base.Update(gameTime);

        }

    }

}
