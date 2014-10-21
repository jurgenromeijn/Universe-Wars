using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Lets the FlyingGameObject fly in a diagonal direction.
    /// </summary>
    class FlyDiagonal : IFlyBehavior
    {

        private float _speed = 0;
        private FlyingGameObject _flyingGameObject;

        /// <summary>
        /// Lets the FlyingGameObject fly in a diagonal direction.
        /// </summary>
        /// <param name="flyingGameObject">The gameobject that has to move diagonal</param>
        public FlyDiagonal(FlyingGameObject flyingGameObject)
        {

            _flyingGameObject = flyingGameObject;
            _speed = (float)Math.Sin(Math.PI / 4) * _flyingGameObject.MaxSpeed; //Calculate the maxspeed for an angle of 45 degrees

        }

        /// <summary>
        /// Lets the FlyingGameObject move diagonal
        /// </summary>
        public void Fly()
        {

            Vector2 tempPosition = _flyingGameObject.Position;

            tempPosition.X -= _speed;
            tempPosition.Y += _speed;

            _flyingGameObject.Position = tempPosition;

        }

    }
}
