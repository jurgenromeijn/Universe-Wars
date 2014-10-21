using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// This class is the basic GameObject class from which all other gamespecific classes that will be drawn should inherrit.
    /// It is able to draw objects based on their properties.
    /// </summary>
    abstract class GameObject : DrawableGameComponent
    {

        private Texture2D _texture;
        private Vector2 _position = new Vector2(0, 0);
        private Rectangle _destinationRectangle = new Rectangle(0, 0, 0, 0);
        private Rectangle _sourceRectangle = new Rectangle(0, 0, 0, 0);
        private Color _color = Color.White;
        private float _rotation = 0;
        public Vector2 _origin = new Vector2(0, 0);
        private SpriteEffects _effects = SpriteEffects.None;
        private float _layerDepth = DrawingLayers.UI;

        public virtual Texture2D Texture
        {
            get { return _texture; }
            set 
            {
                //Update old sourceRectangle instead over overwriting it with a new object, more work but at least we won't be flooding the memory with useless structs.
                _sourceRectangle.X = 0;
                _sourceRectangle.Y = 0;
                _destinationRectangle.Width = value.Width;
                _destinationRectangle.Height = value.Height;
                _sourceRectangle.Width = value.Width;
                _sourceRectangle.Height = value.Height;
                _origin.X = (float)value.Width / 2;
                _origin.Y = (float)value.Height / 2;
                _texture = value;
            }
        }

        public Vector2 Position
        {
            get { return _position; }
            set 
            {
                //Update Desitnation Rectangle
                _destinationRectangle.X = (int)(value.X);
                _destinationRectangle.Y = (int)(value.Y);
                _position = value;
            }
        }

        public Rectangle DestinationRectangle
        {
            get { return _destinationRectangle; }
        }

        protected Rectangle SourceRectangle
        {
            get { return _sourceRectangle; }
            set { _sourceRectangle = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public int Width
        {
            get { return _sourceRectangle.Width; }
            set { _destinationRectangle.Width = value; }
        }

        public int Height
        {
            get { return _sourceRectangle.Height; }
            set {  _destinationRectangle.Height = value; }
        }

        protected Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        protected SpriteEffects Effects
        {
            get { return _effects; }
            set { _effects = value; }
        }

        protected float LayerDepth
        {
            get { return _layerDepth; }
            set { _layerDepth = value; }
        }

        /// <summary>
        /// Setup the GameObject
        /// </summary>
        /// <param name="game">The game in which the GameObject will be drawn</param>
        public GameObject(Game game)
            : base(game)
        {

            game.Components.Add(this);

        }

        /// <summary>
        /// Draw the GameObject in the game
        /// </summary>
        /// <param name="gameTime">The time since the last draw action.</param>
        public override void Draw(GameTime gameTime)
        {

            Game1.SpriteBatch.Draw(_texture, _destinationRectangle, _sourceRectangle, _color, _rotation, _origin, _effects, _layerDepth);

            base.Draw(gameTime);
           
        }

    }

}
