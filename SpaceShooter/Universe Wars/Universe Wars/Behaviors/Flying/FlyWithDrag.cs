using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{

    /// <summary>
    /// Gives drag to a FlyingGameObject, which makes it want to make to certain line on the x-axis.
    /// </summary>
    class FlyWithDrag : IFlyBehavior
    {

        private FlyingGameObject _flyingGameObject;

        /// <summary>
        /// Give drag to a FlyingGameObject.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject that needs the drag,</param>
        public FlyWithDrag(FlyingGameObject flyingGameObject)
        {

            _flyingGameObject = flyingGameObject;

        }

        /// <summary>
        /// Calculate the drag and update the FlyingGameObjects position.
        /// </summary>
        public void Fly()
        {

            Vector2 tempPosition = _flyingGameObject.Position;

            float screenWidth = Game1.Graphics.PreferredBackBufferWidth;

            float drag = (1.2f / (0.25f * screenWidth)) * ((tempPosition.X * -1) + (0.25f * screenWidth));

            tempPosition.X += drag * _flyingGameObject.MaxSpeed;

            _flyingGameObject.Position = tempPosition;

        }

    }

}
