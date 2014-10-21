using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Let the FlyingGameObject fly into the direction of a target and continue onwards once it reached it.
    /// </summary>
    class FlyInDirection : IFlyBehavior
    {

        private FlyingGameObject _flyingGameObject;
        private Vector2 _speed = new Vector2(0, 0);

        /// <summary>
        /// Sets up the base info needed to fly into a certain direction.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject</param>
        /// <param name="target">the target of the flyingGameObject</param>
        public FlyInDirection(FlyingGameObject flyingGameObject, Vector2 target)
        {

            _flyingGameObject = flyingGameObject;

            Vector2 distance = target - _flyingGameObject.Position;
            double tangentAngle = distance.Y / distance.X;
            double Angle = Math.Atan(tangentAngle);

            _flyingGameObject.Rotation = (float)Angle;

            _speed.X = (float)(flyingGameObject.MaxSpeed * Math.Cos(Angle));
            _speed.Y = (float)(flyingGameObject.MaxSpeed * Math.Sin(Angle));
            
        }

        /// <summary>
        /// Fly into the direction of the target
        /// </summary>
        public void Fly()
        {

            Vector2 tempPosition = _flyingGameObject.Position;

            tempPosition += _speed;

            _flyingGameObject.Position = tempPosition;

        }

    }

}
