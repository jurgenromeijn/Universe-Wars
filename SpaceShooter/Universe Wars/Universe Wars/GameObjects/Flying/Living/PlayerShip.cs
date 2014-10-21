using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{
    /// <summary>
    /// This ship can be controlled by the player, it has a secondary shootbehavior for upgrades.
    /// </summary>
    class PlayerShip : LivingGameObject
    {

        private IShootBehavior _secondaryShootBehavior;
        private HealthBar _healthBar;

        public IShootBehavior SecondaryShootBehavior
        {
            get { return _secondaryShootBehavior; }
            set { _secondaryShootBehavior = value; }
        }

        /// <summary>
        /// Set up the player ship
        /// </summary>
        /// <param name="game">The game in which we want to use the PlayerShip.</param>
        public PlayerShip(Game game)
            : base(game)
        {

            MaxSpeed = 4;
            HealthPoints = 10;
            Position = new Vector2(StartPositionHelper.RightXPosition(this), StartPositionHelper.MiddleYPosition());
            Texture = TextureLoader.GetTexture("viper");
            LayerDepth = DrawingLayers.PlayerShip;
            FlyBehavior = new FlyWithDrag(this);
            ShootBehavior = new ShootBullets();
            _secondaryShootBehavior = new ShootNothing();
            DieBehavior = new DieLoseLive();

            _healthBar = new HealthBar(game);

            Debug.WriteLine("Playership is drawn on layer: " + LayerDepth);

        }

        /// <summary>
        /// Update the game's scrollspeed.
        /// </summary>
        /// <param name="gameTime">time since last update</param>
        public override void Update(GameTime gameTime)
        {

            Game1.ActiveLevel.ScrollSpeed = CalculateScrollSpeed();

            base.Update(gameTime);

        }

        /// <summary>
        /// Update the scroll speed of all non player object based on the position of the playership.
        /// </summary>
        /// <returns>the scrollspeed for al non player objects.</returns>
        private float CalculateScrollSpeed()
        {

            float scrollspeed = (Position.X / Game1.Graphics.PreferredBackBufferWidth) * 8;
            return scrollspeed;

        }

        /// <summary>
        /// Fire the secondary weapon.
        /// </summary>
        public void ShootSecondaryWeapon()
        {

            _secondaryShootBehavior.Shoot(this);

        }

        /// <summary>
        /// Let the LivingGameObject be hit by a projectile and calculate it's new health.
        /// Check if the object survived, do the dieing action if it didn't, and return this.
        /// Also updates the livebar.
        /// </summary>
        /// <param name="projectile">The projectile that hit the LivingGameObject.</param>
        /// <returns>Boolean that tells whether the object survived.</returns>
        public override bool TakeHit(Projectile projectile)
        {

            bool survived = base.TakeHit(projectile);

            _healthBar.SetHealth(HealthPoints, StartHealPoints);

            return survived;

        }

        /// <summary>
        /// Dispose of the object and the healtbar.
        /// </summary>
        new public void Dispose()
        {

            _healthBar.Dispose();

            base.Dispose();

        }

    }

}
