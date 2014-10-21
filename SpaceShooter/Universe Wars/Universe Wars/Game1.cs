using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Universe_Wars
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        private static GraphicsDeviceManager _graphics;
        private static SpriteBatch _spriteBatch;
        private static Level _activeLevel;
        private static Player _player;
        private static GameState _state;

        private uint _levelCount = 0;

        public static GraphicsDeviceManager Graphics
        {
            get { return _graphics; }
        }

        public static SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        public static Level ActiveLevel
        {
            get { return Game1._activeLevel; }
        }

        internal static Player Player
        {
            get { return _player; }
        }

        internal static GameState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();

            // Add the player
            _player = new Player(this);
            Components.Add(_player);

            // Set the game state to playing
            _state = GameState.Intro;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load our recources
            TextureLoader.LoadTextures(Content);
            FontLoader.LoadFonts(Content);
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if(_state == GameState.Playing)
            {

                if (_activeLevel == null || _activeLevel.State == LevelState.Finished)
                {

                    Debug.WriteLine(_state);

                    // Start the next level
                    StartNewLevel();

                }

                if (_player.Lives.Count == 0)
                {

                    // Game is over, remove everything and change the state
                    _state = GameState.GameOver;
                    _activeLevel.MakeLevelEmpty();
                    _activeLevel.Dispose();

                }

            }
            else if(_state == GameState.Intro && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {

                _state = GameState.Playing;

            }

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            if (_state == GameState.Intro)
            {

                string introText = "";
                introText += "Universe Wars controls\n\n";
                introText += "Move ship: W, A, S, D or arrow keys\n";
                introText += "Fire gun: Left mouse-button\n";
                introText += "Fire secondary weapon: Right mouse-button\n\n";
                introText += "Press enter to start";

                _spriteBatch.DrawString(FontLoader.GetFont("Verdana"), introText, new Vector2(20, 20), Color.White);

            }
            else if(_state == GameState.Finished)
            {

                // Show finished text
                _spriteBatch.DrawString(FontLoader.GetFont("Verdana"), "The universe has been saved!\n\nPress esc to end the game.", new Vector2(20, 20), Color.White);

            }
            else if (_state == GameState.GameOver)
            {

                // Show Gameover text
                _spriteBatch.DrawString(FontLoader.GetFont("Verdana"), "Game Over\n\nPress esc to end the game.", new Vector2(20, 20), Color.White);

            }
            else
            {

                //Show normal stuff
                base.Draw(gameTime);

            }

            _spriteBatch.End();

        }

        /// <summary>
        /// Start a new level and get rid of the old one. If we already had 3 levels set the Gamestate to finished.
        /// </summary>
        private void StartNewLevel()
        {

            if (_activeLevel != null)
            {

                _activeLevel.Dispose();

            }

            if (_levelCount == 3)
            {

                State = GameState.Finished;
                Debug.WriteLine(_state);

            }
            else
            {

                _activeLevel = new Level(this);
                _levelCount++;

            }

        }

    }

}
