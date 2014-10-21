using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// This object shows the ammount of health the active playership has left.
    /// </summary>
    class HealthBar : UIGameObject
    {

        private HealthBarInside _healthBarinside;

        /// <summary>
        /// Setup the Healthbar and load in the inner part.
        /// </summary>
        /// <param name="game"></param>
        public HealthBar(Game game)
            : base(game)
        {

            Texture = TextureLoader.GetTexture("healthbarbackground");
            Origin = new Vector2(0, Texture.Height);
            Position = new Vector2(20, Game1.Graphics.PreferredBackBufferHeight - 80);
            LayerDepth = LayerDepth - 0.01f; //lower the layerdepth slightly to make sure the inside of the healthbar is in front of the background
            Width = 198;

            _healthBarinside = new HealthBarInside(game);

        }

        /// <summary>
        /// Update the scale for the inner health bar.
        /// </summary>
        /// <param name="curentHealth">The ammount of health the ship has now</param>
        /// <param name="originalHealth">The maximum ammount of health the ship can have</param>
        public void SetHealth(int curentHealth, int originalHealth)
        {

            _healthBarinside.Scale((float)curentHealth / (float)originalHealth);

        }

        /// <summary>
        /// Get rid of this object and the innerHealthBar.
        /// </summary>
        new public void Dispose()
        {

            _healthBarinside.Dispose();

            base.Dispose();

        }

    }
}
