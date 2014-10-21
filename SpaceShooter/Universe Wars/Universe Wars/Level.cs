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
    /// The level class knows all GameObjects and controls interaction between them.
    /// It also spawns new enemies.
    /// </summary>
    public class Level : DrawableGameComponent
    {

        private static uint _instanceCount = 0;
        private uint _levelNumber;
        private float _scrollSpeed = 1; // dependant on the speed of the playership
        private float _enemySpeed = 1; // dependant on which level this is
        private int _enemiesLeft;
        private float _nextEnemySpawntime;
        private LevelState _state;
        private Background _background;

        // Lists with GameObjects \\
        private PlayerShip _playerShip;
        private List<Projectile> _projectiles = new List<Projectile>();
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Upgrade> _upgrades = new List<Upgrade>();

        internal List<Projectile> Projectiles
        {
            get { return _projectiles; }
        }

        internal List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        internal List<Upgrade> Upgrades
        {
            get { return _upgrades; }
        }

        public uint Number
        {
            get { return _levelNumber; }
        }

        public float ScrollSpeed
        {
            get { return _scrollSpeed; }
            set { _scrollSpeed = value; }
        }

        internal LevelState State
        {
            get { return _state; }
        }

        /// <summary>
        /// Update the levelcount and setup the level.
        /// </summary>
        /// <param name="game">The game in which we want tp show the level.</param>
        public Level(Game game)
            : base(game)
        {

            _instanceCount++;
            _levelNumber = _instanceCount;
            _enemySpeed = 1 + ((_instanceCount - 1) * 0.25f);
            _background = new Background(game);

            SetUpLevel();

            Game.Components.Add(this);

        }

        /// <summary>
        /// Add a playership and set the necassery spawn info.
        /// </summary>
        private void SetUpLevel()
        {

            _playerShip = new PlayerShip(Game);
            Game1.Player.Ship = _playerShip;

            _nextEnemySpawntime = 2;
            _enemiesLeft = 20;
            _state = LevelState.Playing;

        }

        /// <summary>
        /// Make all GameObject lists empty and dispose of the objects.
        /// </summary>
        public void MakeLevelEmpty()
        {

            for (int i = 0; i < _projectiles.Count; i++)
            {

                _projectiles[i].Dispose();
                _projectiles.RemoveAt(i);
                i--;

            }

            for (int i = 0; i < _enemies.Count; i++)
            {

                _enemies[i].Dispose();
                _enemies.RemoveAt(i);
                i--;

            }

            for (int i = 0; i < _upgrades.Count; i++)
            {

                _upgrades[i].Dispose();
                _upgrades.RemoveAt(i);
                i--;

            }

            _playerShip.Dispose();
            _playerShip = null;

        }

        /// <summary>
        /// First empty the level and then set it up again.
        /// </summary>
        private void RestartLevel()
        {

            MakeLevelEmpty();
            SetUpLevel();

        }

        /// <summary>
        /// Check whether we need to spawn enemies, have collisio or are at the levels end.
        /// </summary>
        /// <param name="gameTime">time since last update.</param>
        public override void Update(GameTime gameTime)
        {

            _nextEnemySpawntime -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_nextEnemySpawntime <= 0 && _enemiesLeft > 0)
            {

                spawnEnemy();

            }

            CheckProjectileHits();
            CheckPlayerAndEnemyCollisions();
            CheckUpgradeCollisions();

            Debug.WriteLine("Enemies: " + _enemies.Count + "; Projectiles: " + _projectiles.Count);

            if (_enemiesLeft == 0 && _enemies.Count == 0)
            {

                _state = LevelState.Finished;

            }

            base.Update(gameTime);

        }

        /// <summary>
        /// Draw the text which shows the number of this level.
        /// </summary>
        /// <param name="gameTime">Time since the last draw call</param>
        public override void Draw(GameTime gameTime)
        {


            Game1.SpriteBatch.DrawString(FontLoader.GetFont("Verdana"), "Level " + _levelNumber, new Vector2(20, 20), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, DrawingLayers.UI);

            base.Draw(gameTime);

        }

        /// <summary>
        /// Spawn a random enemy.
        /// </summary>
        private void spawnEnemy()
        {

            Random rand = new Random();

            switch (rand.Next(3))
            {
                case 0:
                    Chure chure = new Chure(Game);
                    break;
                case 1:
                    Thege thege = new Thege(Game);
                    break;
                case 2:
                    Sinode sinode = new Sinode(Game);
                    break;
            }

            _enemiesLeft--;

            _nextEnemySpawntime = 1 + (float)(rand.NextDouble() * (2 / _levelNumber));

        }

        /// <summary>
        /// See or any player projectiles hit any enemies or any enemie projectiles hit the player.
        /// </summary>
        private void CheckProjectileHits()
        {

            for (int i = 0; i < _projectiles.Count; i++)
            {

                Projectile projectile = _projectiles[i];

                if (projectile.State == ProjectileState.Active)
                {

                    if (projectile.Shooter == _playerShip)
                    {

                        for (int j = 0; j < _enemies.Count; j++)
                        {

                            Enemy enemy = _enemies[j];

                            if (enemy.State == LivingGameObjectState.Alive && projectile.HitTest(enemy))
                            {

                                // if it is a laser, don't remove it. The laser will remove itself.
                                if (!(projectile is LaserBeam))
                                {

                                    projectile.Dispose();
                                    _projectiles.RemoveAt(i);
                                    i--;

                                }

                                enemy.TakeHit(projectile); // let the enemy remove itself after it's explosion

                            }

                        }

                    }
                    else
                    {

                        if (projectile.HitTest(_playerShip))
                        {

                            projectile.Dispose();
                            _projectiles.RemoveAt(i);
                            i--;

                            if (!_playerShip.TakeHit(projectile))
                            {

                                RestartLevel();
                                break;

                            }

                        }

                    }

                }

            }

        }

        /// <summary>
        /// Check whether the player collided with any enemy. 
        /// If so the playership dies and the level starts over.
        /// </summary>
        private void CheckPlayerAndEnemyCollisions()
        {

           for (int i = 0; i < _enemies.Count; i++)
            {

                Enemy enemy = _enemies[i];

                if(enemy.State == LivingGameObjectState.Alive && _playerShip.HitTest(enemy))
                {

                    enemy.Die();
                    _playerShip.Die();

                    RestartLevel();
                    break;

                }

            }

        }

        /// <summary>
        /// Check whether the player collided with any upgrades and give it to him if he doesn't have it yet.
        /// </summary>
        private void CheckUpgradeCollisions()
        {

            for (int i = 0; i < _upgrades.Count; i++)
            {

                Upgrade upgrade = _upgrades[i];

                if ((_playerShip.SecondaryShootBehavior == null || upgrade.ShootBehavior.GetType() != _playerShip.SecondaryShootBehavior.GetType()) &&
                    _playerShip.HitTest(upgrade))
                {

                    _playerShip.SecondaryShootBehavior = upgrade.ShootBehavior;
                    upgrade.Dispose();
                    _upgrades.RemoveAt(i);
                    i--;

                }
                
            }

        }

        /// <summary>
        /// Make the entire level empty and dispose of it.
        /// </summary>
        new public void Dispose()
        {

            MakeLevelEmpty();
            _background.Dispose();

            base.Dispose();

        }

    }

}
