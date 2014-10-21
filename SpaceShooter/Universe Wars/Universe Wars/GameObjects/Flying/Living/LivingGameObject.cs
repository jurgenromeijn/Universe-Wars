using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{
    /// <summary>
    /// Living gameobject are slightly more inteligent FlyingGameObject. 
    /// They have healtpoints and they can die. They can also shoot.
    /// </summary>
    abstract class LivingGameObject : FlyingGameObject
    {

        private int _healthPoints;
        private int _startHealPoints;
        private LivingGameObjectState _state;
        private IShootBehavior _shootBehavior;
        private IDieBehavior _dieBehavior;
        private IFadeBehavior _fadeBehavior;

        public int HealthPoints
        {
            get { return _healthPoints; }
            protected set 
            {
                _startHealPoints = value;
                _healthPoints = value; 
            }
        }

        public int StartHealPoints
        {
            get { return _startHealPoints; }
        }

        public LivingGameObjectState State
        {
            get { return _state; }
            set { _state = value; }
        }

        protected IShootBehavior ShootBehavior
        {
            get { return _shootBehavior; }
            set { _shootBehavior = value; }
        }

        protected IDieBehavior DieBehavior
        {
            get { return _dieBehavior; }
            set { _dieBehavior = value; }
        }

        public IFadeBehavior FadeBehavior
        {
            get { return _fadeBehavior; }
            set { _fadeBehavior = value; }
        }

        /// <summary>
        /// Sets a standard don't fade behavior and a state, pass on game to FlyingGameObject.
        /// </summary>
        /// <param name="game">The game in which we want to show The LivingGameObject</param>
        public LivingGameObject(Game game)
            : base(game)
        {

            _fadeBehavior = new DoNotFade();
            _state = LivingGameObjectState.Alive;

        }

        /// <summary>
        /// Tell the shootBehavior to shoot
        /// </summary>
        public void Shoot()
        {

            _shootBehavior.Shoot(this);

        }

        /// <summary>
        /// Let the LivingGameObject be hit by a projectile and calculate it's new health.
        /// Check if the object survived, do the dieing action if it didn't, and return this.
        /// </summary>
        /// <param name="projectile">The projectile that hit the LivingGameObject.</param>
        /// <returns>Boolean that tells whether the object survived.</returns>
        public virtual bool TakeHit(Projectile projectile)
        {

            Debug.Write("healthpoints before: " + _healthPoints);

            _healthPoints -= projectile.Damage;

            Debug.WriteLine("; healthpoints after: " + _healthPoints);

            bool survived = (_healthPoints > 0);

            if (!survived)
            {

                _dieBehavior.Die(this);
                _state = LivingGameObjectState.Dead;

            }

            return survived;

        }

        /// <summary>
        /// Let the gameObject die instantly without taking hits.
        /// </summary>
        public void Die()
        {

            _healthPoints = 0;
            _state = LivingGameObjectState.Dead;
            _dieBehavior.Die(this);

        }

        /// <summary>
        /// Let the LivingGameObject do his fade
        /// </summary>
        /// <param name="gameTime">Gametime sice last update</param>
        public override void Update(GameTime gameTime)
        {

            _fadeBehavior.Fade(this);

            base.Update(gameTime);

        }

    }

}
