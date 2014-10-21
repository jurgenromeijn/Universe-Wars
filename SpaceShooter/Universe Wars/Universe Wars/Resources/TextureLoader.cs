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
    /// This static class loads all textures and makes the accesable everywhere in the game.
    /// </summary>
    static class TextureLoader
    {

        private static Dictionary<String, Texture2D> _textures = new Dictionary<String, Texture2D>();
        private static ContentManager _content;

        /// <summary>
        /// Load all the textures we need.
        /// </summary>
        /// <param name="content">The content loader that can be used.</param>
        public static void LoadTextures(ContentManager content)
        {

            _content = content;

            Debug.WriteLine("load textures");

            LoadTexture("empty", "empty");
            LoadTexture("starscape", "Backgrounds//starscape");
            LoadTexture("crosshair", "UI//crosshair");
            LoadTexture("heart", "UI//heart"); 
            LoadTexture("healthbarbackground", "UI//healthbar-background");
            LoadTexture("healthbarinside", "UI//healthbar-inside");
            LoadTexture("viper", "viper");
            LoadTexture("explosion", "explosion");
            LoadTexture("chure", "Enemies//chure");
            LoadTexture("thege", "Enemies//thege");
            LoadTexture("sinode", "Enemies//sinode");
            LoadTexture("bullet", "Projectiles//bullet");
            LoadTexture("rocket", "Projectiles//rocket");
            LoadTexture("laser", "Projectiles//laser");
            LoadTexture("bomb", "Projectiles//bomb");
            LoadTexture("bulletIcon", "WeaponIcons//bullet");
            LoadTexture("laserIcon", "WeaponIcons//laser");
            LoadTexture("rocketIcon", "WeaponIcons//rocket");
            LoadTexture("guidedMissileIcon", "WeaponIcons//guidedmissile");

            Debug.WriteLine(_textures.Count);

        }

        /// <summary>
        /// Load a specific font and add it to the list.
        /// </summary>
        /// <param name="fontName">The name that will be used to get the texture back from the list.</param>
        /// <param name="assetName">The name used to identify the asset in the texture folder.</param>
        private static void LoadTexture(string textureName, string assetName)
        {

            Texture2D texture = _content.Load<Texture2D>("Textures//" + assetName);
            _textures.Add(textureName, texture);

        }

        /// <summary>
        /// Look for a texture in the texture list, if it can't be found return an empty texture or null.
        /// </summary>
        /// <param name="fontName">The name of the texture we try to find.</param>
        /// <returns>The texture.</returns>
        public static Texture2D GetTexture(string textureName)
        {

            if (_textures.ContainsKey(textureName))
            {

                Debug.WriteLine("returned texture: " + textureName);

                return _textures[textureName];

            }
            else if (_textures.ContainsKey("empty"))
            {

                Debug.WriteLine("coudn't find texture: " + textureName + "; returned empty texture");

                return _textures["empty"];

            }
            else
            {

                Debug.WriteLine("coudn't find texture: " + textureName + "; empty texture not present, returned null.");

                return null;

            }

        }

    }

}
