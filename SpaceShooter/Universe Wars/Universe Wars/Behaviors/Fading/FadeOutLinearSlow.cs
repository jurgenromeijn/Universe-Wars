using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Fade out a GameObject slowly in a linear fashion.
    /// </summary>
    class FadeOutLinearSlow : IFadeBehavior
    {
        /// <summary>
        /// Make the GameObject slightly less visible.
        /// </summary>
        /// <param name="gameObject">The GameObject that has to fade.</param>
        public void Fade(GameObject gameObject)
        {

            Color tempColor = gameObject.Color;

            tempColor.R = (byte)MathHelper.Clamp((tempColor.R - 15), 0, 255);
            tempColor.G = (byte)MathHelper.Clamp((tempColor.G - 15), 0, 255);
            tempColor.B = (byte)MathHelper.Clamp((tempColor.B - 15), 0, 255);
            tempColor.A = (byte)MathHelper.Clamp((tempColor.A - 15), 0, 255);

            gameObject.Color = tempColor;

        }

    }

}
