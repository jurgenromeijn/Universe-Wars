using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{

    /// <summary>
    /// This controller handles all the input from the keyboard and the mouse
    /// </summary>
    class KeyboardMouseBehavior : IController
    {

        private KeyboardState _keyboardState;
        private MouseState _mouseState;
        private bool _canFire = false;

        public void UpdateState()
        {

            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();

        }

        /// <summary>
        /// Check in which direction the playership will have to move
        /// </summary>
        /// <param name="ship">The playership</param>
        public void CheckMovement(PlayerShip ship)
        {

            Vector2 direction = new Vector2(0, 0);

            if (_keyboardState.IsKeyDown(Keys.A) || _keyboardState.IsKeyDown(Keys.Left))
            {

                direction.X = direction.X - 1;

            }

            if (_keyboardState.IsKeyDown(Keys.D) || _keyboardState.IsKeyDown(Keys.Right))
            {

                direction.X = direction.X + 1;

            }

            if (_keyboardState.IsKeyDown(Keys.W) || _keyboardState.IsKeyDown(Keys.Up))
            {

                direction.Y = direction.Y - 1;

            }

            if (_keyboardState.IsKeyDown(Keys.S) || _keyboardState.IsKeyDown(Keys.Down))
            {

                direction.Y = direction.Y + 1;

            }

            Vector2 tempPostion = ship.Position;

            tempPostion.Y = MathHelper.Clamp((tempPostion.Y + (direction.Y * ship.MaxSpeed)), ship.Rectangle.Height / 2, Game1.Graphics.PreferredBackBufferHeight - (ship.Rectangle.Height / 2));
            tempPostion.X += direction.X * ship.MaxSpeed;

            ship.Position = tempPostion;

        }

        /// <summary>
        /// Updates the position and the color of the crosshair acording to the mouse position.
        /// It also checks whether the player can actaully fire a bullet (the ship will only be able to fire in a 180 degree forward dome)
        /// </summary>
        /// <param name="ship">the playership</param>
        /// <param name="crosshair">the crosshair</param>
        public void UpdateCrosshair(PlayerShip ship, Crosshair crosshair)
        {

            Vector2 tempPosition = crosshair.Position;

            tempPosition.X = _mouseState.X;
            tempPosition.Y = _mouseState.Y;

            crosshair.Position = tempPosition;

            if (tempPosition.X < ship.Position.X)
            {

                Color tempColor = crosshair.Color;
                tempColor.R = 128;
                tempColor.G = 0;
                tempColor.B = 0;
                tempColor.A = 128;

                crosshair.Color = tempColor;

                _canFire = false;

            }
            else
            {

                crosshair.Color = Color.White;

                _canFire = true;

            }

        }

        /// <summary>
        /// Check whether the player tried to fire and if so command the playership to fire.
        /// </summary>
        /// <param name="ship">the playership</param>
        public void CheckFire(PlayerShip ship)
        {

            if (_canFire)
            {

                if (_mouseState.LeftButton == ButtonState.Pressed)
                {

                    ship.Shoot();

                }

                if (_mouseState.RightButton == ButtonState.Pressed)
                {

                    ship.ShootSecondaryWeapon();

                }

            }

        }

    }

}
