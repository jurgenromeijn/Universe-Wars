using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Actively track and follow a GameObject.
    /// </summary>
    class FlyTowardsObject : IFlyBehavior
    {

        private FlyingGameObject _flyingGameObject;
        private Vector2 _speed = new Vector2(0, 0);
        private GameObject _target;
        private double _lastAngle = 0;
        
        /// <summary>
        /// Make a FlyingGameObject actively track and follow a GameObject.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject that has to follow the target</param>
        /// <param name="target">The target that has to be followed</param>
        public FlyTowardsObject(FlyingGameObject flyingGameObject, GameObject target)
        {

            _flyingGameObject = flyingGameObject;
            _target = target;
            
        }

        /// <summary>
        /// Follow the GameObject.
        /// </summary>
        public void Fly()
        {

            Vector2 distance = _target.Position - _flyingGameObject.Position;

            if (Math.Abs(distance.X) <= _flyingGameObject.MaxSpeed && Math.Abs(distance.Y) <= _flyingGameObject.MaxSpeed)
            {

                _flyingGameObject.Position = _target.Position;

            }
            else
            {

                double tangentAngle = distance.Y / distance.X;

                double Angle = Math.Atan(tangentAngle);

                if (_flyingGameObject.Position.X > _target.Position.X)
                {

                    Angle += Math.PI;

                }

                _lastAngle = Angle;

                _flyingGameObject.Rotation = (float)Angle;

                _speed.X = (float)(_flyingGameObject.MaxSpeed * Math.Cos(Angle));
                _speed.Y = (float)(_flyingGameObject.MaxSpeed * Math.Sin(Angle));

                Vector2 tempPosition = _flyingGameObject.Position;

                tempPosition += _speed;

                _flyingGameObject.Position = tempPosition;

            }

        }
    
    }
}
