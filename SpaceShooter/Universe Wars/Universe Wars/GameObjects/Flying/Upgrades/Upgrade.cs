using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    /// <summary>
    /// This class is the parent for all upgrades. 
    /// It's children will fly at normal scroll speed.
    /// It has a shoot behavior on it that can be used to upgrade the playership.
    /// </summary>
    abstract class Upgrade : FlyingGameObject
    {

        private IShootBehavior _shootBehavior;

        public IShootBehavior ShootBehavior
        {
            get { return _shootBehavior; }
            protected set { _shootBehavior = value; }
        }

        /// <summary>
        /// Set up the Upgrade.
        /// </summary>
        /// <param name="game">The game in which we want to show the upgrade.</param>
        public Upgrade(Game game) 
            : base(game)
        {

            FlyBehavior = new FlyScrollSpeed(this);
            LayerDepth = DrawingLayers.Upgrades;

            Game1.ActiveLevel.Upgrades.Add(this);

        }

    }

}
