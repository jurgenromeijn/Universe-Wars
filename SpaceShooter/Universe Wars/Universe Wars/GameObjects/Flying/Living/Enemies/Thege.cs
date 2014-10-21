using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The thege always moves down diagonal from the top right. It is a very prodictable enemy and therfor has the most healthpoints. 
    /// </summary>
    class Thege : Enemy
    {

        /// <summary>
        /// Set up the thege.
        /// </summary>
        /// <param name="game">The game in which we want to see the thege.</param>
        public Thege(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("thege");
            Position = new Vector2(StartPositionHelper.RightXPosition(this), StartPositionHelper.TopYPosition(this));
            MaxSpeed = 2;
            HealthPoints = 4;

            MultipleFlyBehaviorComposite tempFlyBehavior = new MultipleFlyBehaviorComposite();

            tempFlyBehavior.FlyBehaviors.Add(new FlyScrollSpeed(this));
            tempFlyBehavior.FlyBehaviors.Add(new FlyDiagonal(this));

            FlyBehavior = tempFlyBehavior;
            ShootBehavior = new ShootNothing();

        }

    }

}
