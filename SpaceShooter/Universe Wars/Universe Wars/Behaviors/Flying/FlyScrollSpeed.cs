using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{

    /// <summary>
    /// Fly with the standard enviorment scrollspeed. This is calculated based on the playership speed.
    /// </summary>
    class FlyScrollSpeed : IFlyBehavior
    {

        private FlyingGameObject _flyingGameObject;

        /// <summary>
        /// Make a FlyingGameObject fly with the standard enviorment scrollspeed.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject that has to fly the regular scrollspeed</param>
        public FlyScrollSpeed(FlyingGameObject flyingGameObject)
        {

            _flyingGameObject = flyingGameObject;

        }

        /// <summary>
        /// Fly with the scrollspeed.
        /// </summary>
        public void Fly()
        {

            float scrollSpeed = Game1.ActiveLevel.ScrollSpeed;

            Vector2 tempPosition = _flyingGameObject.Position;

            tempPosition.X -= scrollSpeed;

            _flyingGameObject.Position = tempPosition;

        }
    }
}
