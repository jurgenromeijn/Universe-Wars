using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This static class loads all fonts and makes the accesable everywhere in the game.
    /// </summary>
    static class FontLoader
    {

        private static Dictionary<String, SpriteFont> _fonts = new Dictionary<String, SpriteFont>();
        private static ContentManager _content;
        
        /// <summary>
        /// Load all the fonts we need.
        /// </summary>
        /// <param name="content">The content loader that can be used.</param>
        public static void LoadFonts(ContentManager content)
        {

            _content = content;

            LoadFont("Verdana", "Verdana");

            Debug.WriteLine(_fonts.Count);

        }

        /// <summary>
        /// Load a specific font and add it to the list.
        /// </summary>
        /// <param name="fontName">The name that will be used to get the font back from the list.</param>
        /// <param name="assetName">The name used to identify the asset in the fonts folder.</param>
        private static void LoadFont(string fontName, string assetName)
        {

            SpriteFont font = _content.Load<SpriteFont>("Fonts//" + assetName);
            _fonts.Add(fontName, font);

        }

        /// <summary>
        /// Look for a font in the font list, if it can't be used return null.
        /// </summary>
        /// <param name="fontName">The name of the font we try to find.</param>
        /// <returns>The font.</returns>
        public static SpriteFont GetFont(string fontName)
        {

            if (_fonts.ContainsKey(fontName))
            {

                return _fonts[fontName];

            }
            else
            {

                return null;

            }

        }

    }

}
