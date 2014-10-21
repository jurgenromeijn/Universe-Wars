using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// The player controlls everything. He can have a crosshair and lives.
    /// He has a contoller which allows hit to steer his ship.
    /// </summary>
    public class Player : GameComponent
    {

        private IController _controller;
        private PlayerShip _ship;
        private Crosshair _crosshair;
        private Stack<Live> _lives = new Stack<Live>();

        internal PlayerShip Ship
        {
            get { return _ship; }
            set { _ship = value; }
        }

        internal Crosshair Crosshair
        {
            get { return _crosshair; }
        }

        internal Stack<Live> Lives
        {
            get { return _lives; }
        }

        /// <summary>
        /// Set up the Player by giving him a crosshair, a controller and lives.
        /// </summary>
        /// <param name="game">The game in which we want to player to be.</param>
        public Player(Game game)
            : base(game)
        {

            _crosshair = new Crosshair(game);

            _controller = new KeyboardMouseBehavior();

            for (int i = 0; i < 3; i++)
            {

                Live live = new Live(game);

                _lives.Push(live);

            }

        }

        /// <summary>
        /// Check the players input.
        /// </summary>
        /// <param name="gameTime">Time since last update.</param>
        public override void Update(GameTime gameTime)
        {

            if (_ship != null)
            {

                _controller.UpdateState();
                _controller.UpdateCrosshair(_ship, _crosshair);
                _controller.CheckMovement(_ship);
                _controller.CheckFire(_ship);

            }

            base.Update(gameTime);
        }

    }
}
