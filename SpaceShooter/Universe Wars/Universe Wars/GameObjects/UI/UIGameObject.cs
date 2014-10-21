using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// This object doesn't do an awful lot more than a normal GameObject, other than showing sprites pixel perfect for UI elements.
    /// </summary>
    class UIGameObject : GameObject
    {

        public override Texture2D Texture
        {
            set
            {
                //make sure origin is on a whole pixel, this will keep UI elements crisp.
                base.Texture = value;

                Vector2 tempOrigin = Origin;

                tempOrigin.X = (int)Origin.X;
                tempOrigin.Y = (int)Origin.Y;

                Origin = tempOrigin;

            }
        }

        /// <summary>
        /// Set the layerDepth to UI depth by defualt.
        /// </summary>
        /// <param name="game">The game in which we will show the UI element.</param>
        public UIGameObject(Game game)
            : base(game)
        {

            LayerDepth = DrawingLayers.UI;

        }

    }
}
