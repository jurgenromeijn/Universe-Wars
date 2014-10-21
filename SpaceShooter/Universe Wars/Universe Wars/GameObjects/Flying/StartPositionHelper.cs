using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    static class StartPositionHelper
    {

        /// <summary>
        /// Calculate the vertical top position in the screen for the FlyingGameObject.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject</param>
        /// <returns>The vertical top position for the FlyingGameObject</returns>
        public static float TopYPosition(FlyingGameObject flyingGameObject)
        {

            return flyingGameObject.DestinationRectangle.Height / 2;

        }

        /// <summary>
        /// Calculate the minimal vertical position in the screen for the FlyingGameObject.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject</param>
        /// <returns>The minimum vertical position for the FlyingGameObject</returns>
        public static float BottomYPosition(FlyingGameObject flyingGameObject)
        {

            return Game1.Graphics.PreferredBackBufferHeight - (flyingGameObject.DestinationRectangle.Height / 2);

        }

        /// <summary>
        /// Calculate the vertical center position in the screen for the FlyingGameObject.
        /// </summary>
        /// <returns>The vertical center position for the FlyingGameObject</returns>
        public static float MiddleYPosition()
        {

            return Game1.Graphics.PreferredBackBufferHeight / 2;

        }

        /// <summary>
        /// Calculate a radom position on the Y-axis for the FlyingGameObject.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject</param>
        /// <returns>The random Y position for the FlyingGameObject</returns>
        public static float RandomYPosition(FlyingGameObject flyingGameObject)
        {

            Random rand = new Random(DateTime.Now.Millisecond);

            return rand.Next((int)TopYPosition(flyingGameObject), (int)BottomYPosition(flyingGameObject));

        }

        /// <summary>
        /// Create a position on the X-axis that is just out of the screen on the right side.
        /// </summary>
        /// <param name="flyingGameObject">The FlyingGameObject</param>
        /// <returns>The X position on the right side</returns>
        public static float RightXPosition(FlyingGameObject flyingGameObject)
        {

            return Game1.Graphics.PreferredBackBufferWidth + (flyingGameObject.DestinationRectangle.Width / 2);

        }

    }

}
