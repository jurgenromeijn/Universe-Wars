using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Makes a FlyingGameObject move in a ZigZag manner.
    /// </summary>
    class FlyZigZag : IFlyBehavior
    {

        private float _minPosition;
        private float _maxPosition;
        private float _speed;
        private FlyingGameObject _flyingGameObject;

        /// <summary>
        /// Make a FlyingGameObject move in a zigzag manner.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject that has to zigzag.</param>
        public FlyZigZag(FlyingGameObject flyingGameObject)
        {

            _flyingGameObject = flyingGameObject;
            CalculateMaxAndMinPositions(_flyingGameObject.DestinationRectangle.Height / 2);

            Random rand = new Random();

            _speed = ((float)(rand.NextDouble() * 2) -1) * flyingGameObject.MaxSpeed;

        }

        /// <summary>
        /// Let the FlyingGameObject fly and let it bounce of the edge of the screen if needed.
        /// </summary>
        public void Fly()
        {

            Vector2 tempPosition = _flyingGameObject.Position;


            if (tempPosition.Y <= _minPosition || tempPosition.Y >= _maxPosition)
            {

                _speed = -_speed;

            }

            tempPosition.Y += _speed;
            tempPosition.X -= 0.5f;

            _flyingGameObject.Position = tempPosition;

        }

        private void CalculateMaxAndMinPositions(float textureRadius)
        {

            _minPosition = textureRadius;
            _maxPosition = Game1.Graphics.PreferredBackBufferHeight - textureRadius;

        }

    }

}
