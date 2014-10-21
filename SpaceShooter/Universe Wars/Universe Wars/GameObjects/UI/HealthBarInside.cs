using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// This object is nothing more than a Red bar inside the healthbar.
    /// </summary>
    class HealthBarInside : UIGameObject
    {

        /// <summary>
        /// Setup the basic stuff for the innerHealthBar.
        /// </summary>
        /// <param name="game">The game in which we want to show the InnerHealthBar.</param>
        public HealthBarInside(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("healthbarinside");
            Origin = new Vector2(-4, Texture.Height + 4);
            Position = new Vector2(20, Game1.Graphics.PreferredBackBufferHeight - 80);

        }

        /// <summary>
        /// Scale the size of the sprite to the desired scale.
        /// </summary>
        /// <param name="scale">The scale the InnerHealthBar has to be compared to the original width.</param>
        public void Scale(float scale)
        {

            Width = (int)(Texture.Width * scale);

        }

    }
}
