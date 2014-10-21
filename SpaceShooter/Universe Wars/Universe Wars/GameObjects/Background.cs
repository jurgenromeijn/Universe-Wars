using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This GameOBject draws a nice starscape in the background.
    /// </summary>
    class Background : GameObject
    {

        /// <summary>
        /// Draw a screenfilling starscape on the background.
        /// </summary>
        /// <param name="game">The game in which the background has to be drawn.</param>
        public Background(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("starscape");
            LayerDepth = DrawingLayers.Background;
            Origin = new Vector2(0, 0);

        }

    }
}
