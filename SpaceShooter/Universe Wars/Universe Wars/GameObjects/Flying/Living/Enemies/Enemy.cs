using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    /// <summary>
    /// Enemies are hostile. They  also all get drawn on slightly different layers to prevent overlap.
    /// </summary>
    class Enemy : LivingGameObject
    {

        private static int _instanceCount = 0;

        /// <summary>
        /// Set up the enemy.
        /// </summary>
        /// <param name="game">The game in which we want the enemy to be.</param>
        public Enemy(Game game)
            : base(game)
        {

            _instanceCount++;

            LayerDepth = DrawingLayers.Enemies + (_instanceCount / 10000);

            MultipleDieBehaviorsComposite tempDieBehaviors = new MultipleDieBehaviorsComposite();

            tempDieBehaviors.DieBehaviors.Add(new DieExplode());
            tempDieBehaviors.DieBehaviors.Add(new DieDropUpgrade());

            DieBehavior = tempDieBehaviors;

            Game1.ActiveLevel.Enemies.Add(this);

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            if (Color.R < 1)
            {
                Game1.ActiveLevel.Enemies.Remove(this);
                Dispose();
            }

        }

    }
}
