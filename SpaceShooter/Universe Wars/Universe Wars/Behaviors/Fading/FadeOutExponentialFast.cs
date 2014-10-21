using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Fade out a GameObject fast in an exponential fashion.
    /// </summary>
    class FadeOutExponentialFast : IFadeBehavior
    {
        /// <summary>
        /// Make the GameObject slightly less visible.
        /// </summary>
        /// <param name="gameObject">The GameObject that has to fade.</param>
        public void Fade(GameObject gameObject)
        {

            Color tempColor = gameObject.Color;

            tempColor.R = (byte)(tempColor.R / 1.15);
            tempColor.G = (byte)(tempColor.G / 1.15);
            tempColor.B = (byte)(tempColor.B / 1.15);
            tempColor.A = (byte)(tempColor.A / 1.15);

            gameObject.Color = tempColor;

        }

    }

}
