using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// This class describes projectiles. It has damage on it and it knows who fired it. 
    /// It inherits form FlyingGameObject and therefore is able to fly and has hit detection.
    /// You can't have any instances of projectiles, but can of it's children.
    /// </summary>
    abstract class Projectile : FlyingGameObject
    {

        private int _damage;
        private LivingGameObject _shooter;
        private ProjectileState _state = ProjectileState.Active;

        public int Damage
        {
            get { return _damage; }
            protected set { _damage = value; }
        }

        public LivingGameObject Shooter
        {
            get { return _shooter; }
        }

        public ProjectileState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// Set up the projectile and add it to the projectile list in the active level.
        /// </summary>
        /// <param name="game">The game in which we want the projectile to show up.</param>
        /// <param name="startPosition">The startposition of the projectile.</param>
        /// <param name="shooter">The LivingGameObject that fired the projectile.</param>
        public Projectile(Game game, Vector2 startPosition, LivingGameObject shooter)
            : base(game)
        {

            Position = startPosition;
            _shooter = shooter;
            LayerDepth = DrawingLayers.Projectiles;

            Game1.ActiveLevel.Projectiles.Add(this);

        }

    }
}
