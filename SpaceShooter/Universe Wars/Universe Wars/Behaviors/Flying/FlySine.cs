using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{

    /// <summary>
    /// Fly in a sinus patern.
    /// </summary>
    class FlySine : IFlyBehavior
    {

        private FlyingGameObject _flyingGameObject;
        private float _minPosition;
        private float _maxPosition;
        private double _radials;
        private double _radialIncrements;

        /// <summary>
        /// Make a FlyingGameObject fly in a sinus patern.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGamePatern that has to fly the sinus patern</param>
        public FlySine(FlyingGameObject flyingGameObject)
        {

            _flyingGameObject = flyingGameObject;
            CalculateMaxAndMinPositions(_flyingGameObject.DestinationRectangle.Height / 2);

            Random rand = new Random();

            _radials = rand.NextDouble() * 2 * Math.PI;
            _radialIncrements = ((rand.Next(2) * 2) - 1) * 0.02;

        }

        /// <summary>
        /// Fly in the sinus patern.
        /// </summary>
        public void Fly()
        {

            Vector2 tempPosition = _flyingGameObject.Position;

            tempPosition.X -= _flyingGameObject.MaxSpeed;
            tempPosition.Y = (float)((((Math.Sin(_radials) + 1) / 2) * (_maxPosition - _minPosition)) + _minPosition);

            _flyingGameObject.Position = tempPosition;

            _radials += _radialIncrements;

        }

        private void CalculateMaxAndMinPositions(float textureRadius)
        {

            _minPosition = textureRadius;
            _maxPosition = Game1.Graphics.PreferredBackBufferHeight - textureRadius;

        }

    }

}
