using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This object shows a heart that resembles a player live.
    /// </summary>
    class Live : UIGameObject
    {

        private static uint _instaceCount;
        private static uint _instanceNumber;

        /// <summary>
        /// Setup the basic stuff for the heart and position it.
        /// </summary>
        /// <param name="game"></param>
        public Live(Game game)
            : base(game)
        {

            _instaceCount++;
            _instanceNumber = _instaceCount;

            Texture = TextureLoader.GetTexture("heart");
            Origin = new Vector2(0, Texture.Height);
            Position = new Vector2(20 + (70 * (_instanceNumber - 1)), Game1.Graphics.PreferredBackBufferHeight - 20);

        }

        /// <summary>
        /// Get rid of the heart and lower the instanceCount.
        /// </summary>
        new public void Dispose()
        {

            _instaceCount--;

            base.Dispose();

        }

    }
}
