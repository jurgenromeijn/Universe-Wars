using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Flies in a sinus patern. Is the fastest enemy and therefor has the least healthpoints.
    /// </summary>
    class Sinode : Enemy
    {

        /// <summary>
        /// Set up the sinode.
        /// </summary>
        /// <param name="game">The game in which we want to show the sinode.</param>
        public Sinode(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("sinode");
            Position = new Vector2(StartPositionHelper.RightXPosition(this), 0);
            MaxSpeed = 2;
            HealthPoints = 2;

            MultipleFlyBehaviorComposite tempFlyBehavior = new MultipleFlyBehaviorComposite();

            tempFlyBehavior.FlyBehaviors.Add(new FlyScrollSpeed(this));
            tempFlyBehavior.FlyBehaviors.Add(new FlySine(this));

            FlyBehavior = tempFlyBehavior;
            ShootBehavior = new ShootNothing();

        }

    }

}
