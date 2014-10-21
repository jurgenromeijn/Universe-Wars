using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// A GameObject that flies arround. It also has hittest capabilities, both Rectangle intersecting and pixel comparisons (including rotations).
    /// </summary>
    abstract class FlyingGameObject : GameObject
    {

        private float _maxSpeed;
        private IFlyBehavior _flyBehavior;

        private Matrix _transform;
        private Rectangle _rectangle = new Rectangle(0, 0, 0, 0);
        private Color[] _textureData;

        public override Texture2D Texture
        {
            set
            {
                base.Texture = value;
                _textureData = new Color[value.Width * value.Height];
                value.GetData(_textureData);
            }
        }

        public IFlyBehavior FlyBehavior
        {
            get { return _flyBehavior; }
            set { _flyBehavior = value; }
        }

        public float MaxSpeed
        {
            get { return _maxSpeed; }
            protected set { _maxSpeed = value; }
        }

        public Rectangle Rectangle
        {
            get { return _rectangle; }
        }

        public Matrix Transform
        {
            get { return _transform; }
        }

        public Color[] TextureData
        {
            get { return _textureData; }
        }

        public FlyingGameObject(Game game)
            : base(game)
        {

        }

        /// <summary>
        /// Let the flybehavior run it's course, calculate rectangles 
        /// and transforms for hittesting and check if the object is 
        /// still inside the screen, otherwise dispose of it.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            _flyBehavior.Fly();
            CalculateTransform();
            CalculateBoundingRectangle();

            if (Position.X < -Rectangle.Width ||
                Position.Y < -Rectangle.Height ||
                Position.X > (Game1.Graphics.PreferredBackBufferWidth + Rectangle.Width) ||
                Position.Y > (Game1.Graphics.PreferredBackBufferHeight + Rectangle.Height))
            {

                Remove();

            }

            base.Update(gameTime);

        }

        /// <summary>
        /// First, for performance reasons, check whether the rectangles overlap.
        /// If they do, continue and do hit detection bij pixel intersecting.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool HitTest(FlyingGameObject target)
        {

            // Only do PixelChecking when the rectangles of both FlyingGameObject overlap
            if (_rectangle.Intersects(target._rectangle))
            {

                return IntersectPixels(target);
                
            }

            return false;

        }

        /// <summary>
        /// Determines if there is overlap of the non-transparent pixels between two
        /// sprites.
        /// </summary>
        /// <see cref="http://create.msdn.com/en-US/education/catalog/tutorial/collision_2d_perpixel_transformed"/>
        /// <returns>True if non-transparent pixels overlap; false otherwise</returns>
        private bool IntersectPixels(FlyingGameObject target)
        {

            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            Matrix transformThisToTarget = this._transform * Matrix.Invert(target.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformThisToTarget);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformThisToTarget);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            Vector2 yPosInTarget = Vector2.Transform(Vector2.Zero, transformThisToTarget);

            // For each row of pixels in A
            for (int yThis = 0; yThis < SourceRectangle.Height; yThis++)
            {
                // Start at the beginning of the row
                Vector2 posInTarget = yPosInTarget;

                // For each pixel in this row
                for (int xThis = 0; xThis < SourceRectangle.Width; xThis++)
                {
                    // Round to the nearest pixel
                    int xTarget = (int)Math.Round(posInTarget.X);
                    int yTarget = (int)Math.Round(posInTarget.Y);

                    // If the pixel lies within the bounds of B
                    if (0 <= xTarget && xTarget < target.SourceRectangle.Width &&
                        0 <= yTarget && yTarget < target.SourceRectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        Color colorThis = _textureData[xThis + yThis * SourceRectangle.Width];
                        Color colorTarget = target.TextureData[xTarget + yTarget * target.SourceRectangle.Width];

                        // If both pixels are not completely transparent,
                        if (colorThis.A > 63 && colorTarget.A > 63)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInTarget += stepX;
                }

                // Move to the next row
                yPosInTarget += stepY;
            }

            // No intersection found
            return false;

        }

        /// <summary>
        /// Create a matrix for our GameObject. This matrix can be compared to other matrixes.
        /// </summary>
        private void CalculateTransform()
        {

            Vector2 scale;


            if (SourceRectangle.Width != 0 && SourceRectangle.Height != 0)
            {

                scale = new Vector2(DestinationRectangle.Width / SourceRectangle.Width, DestinationRectangle.Height / SourceRectangle.Height);

            }
            else
            {

                scale = new Vector2(1, 1);

            }

            _transform =
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateScale(new Vector3(scale, 1)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateTranslation(new Vector3(Position, 0.0f));

        }

        /// <summary>
        /// Calculates an axis aligned rectangle which fully contains an arbitrarily
        /// transformed axis aligned rectangle.
        /// </summary>
        /// <see cref="http://create.msdn.com/en-US/education/catalog/tutorial/collision_2d_perpixel_transformed"/>
        private void CalculateBoundingRectangle()
        {
            // Get all four corners in local space
            Vector2 leftTop = new Vector2(SourceRectangle.Left, SourceRectangle.Top);
            Vector2 rightTop = new Vector2(SourceRectangle.Right, SourceRectangle.Top);
            Vector2 leftBottom = new Vector2(SourceRectangle.Left, SourceRectangle.Bottom);
            Vector2 rightBottom = new Vector2(SourceRectangle.Right, SourceRectangle.Bottom);

            // Transform all four corners into work space
            Vector2.Transform(ref leftTop, ref _transform, out leftTop);
            Vector2.Transform(ref rightTop, ref _transform, out rightTop);
            Vector2.Transform(ref leftBottom, ref _transform, out leftBottom);
            Vector2.Transform(ref rightBottom, ref _transform, out rightBottom);

            // Find the minimum and maximum extents of the rectangle in world space
            Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                                      Vector2.Min(leftBottom, rightBottom));
            Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                                      Vector2.Max(leftBottom, rightBottom));

            _rectangle.X = (int)min.X;
            _rectangle.Y = (int)min.Y;
            _rectangle.Width = (int)(max.X - min.X);
            _rectangle.Height = (int)(max.Y - min.Y);

        }

        /// <summary>
        /// If a FlyingGameObject goes out of bounds, remove it from our activelevels lists and dispose of it.
        /// </summary>
        private void Remove()
        {

            if (this is Projectile)
            {

                Game1.ActiveLevel.Projectiles.Remove((Projectile)this);

            }
            else if (this is Enemy)
            {

                Game1.ActiveLevel.Enemies.Remove((Enemy)this);

            }
            else if (this is Upgrade)
            {

                Game1.ActiveLevel.Upgrades.Remove((Upgrade)this);

            }

            Dispose();

        }

    }

}
