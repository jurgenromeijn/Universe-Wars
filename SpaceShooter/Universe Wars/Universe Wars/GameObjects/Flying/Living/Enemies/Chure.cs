using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The chure moves diagonal in a zigzag manner, it also drops bombs at random moments.
    /// </summary>
    class Chure : Enemy
    {

        private float _nextBombSpawnTime;

        /// <summary>
        /// Set up the chure
        /// </summary>
        /// <param name="game">The game in which we want do show the chure.</param>
        public Chure(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("chure");
            Position = new Vector2(StartPositionHelper.RightXPosition(this), StartPositionHelper.RandomYPosition(this));
            MaxSpeed = 2;
            HealthPoints = 3;

            MultipleFlyBehaviorComposite tempFlyBehavior = new MultipleFlyBehaviorComposite();

            tempFlyBehavior.FlyBehaviors.Add(new FlyScrollSpeed(this));
            tempFlyBehavior.FlyBehaviors.Add(new FlyZigZag(this));

            FlyBehavior = tempFlyBehavior;
            ShootBehavior = new ShootBomb();

            CalculateNextBombSpanwTime();

        }

        /// <summary>
        /// If the time is right, spawn a bomb.
        /// </summary>
        /// <param name="gameTime">Time since last update.</param>
        public override void Update(GameTime gameTime)
        {

            _nextBombSpawnTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_nextBombSpawnTime <= 0 && State == LivingGameObjectState.Alive)
            {

                ShootBehavior.Shoot(this);

                CalculateNextBombSpanwTime();

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Calculate the spawn time for the next bomb, this depends on the level number and is always more than 1.
        /// </summary>
        private void CalculateNextBombSpanwTime()
        {

            Random rand = new Random();

            _nextBombSpawnTime = 1 + (float)(rand.NextDouble() * (5 / Game1.ActiveLevel.Number));

        }

    }

}
