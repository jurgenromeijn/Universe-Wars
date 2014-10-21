using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The crosshair that the player will be able to use to aim.
    /// </summary>
    class Crosshair : UIGameObject
    {

        /// <summary>
        /// Set up the crosshair.
        /// </summary>
        /// <param name="game">The game in which the crosshair has to be shown.</param>
        public Crosshair(Game game) 
            : base(game)
        {

            Texture = TextureLoader.GetTexture("crosshair");
            LayerDepth = DrawingLayers.Crosshair;

        }

    }
}
