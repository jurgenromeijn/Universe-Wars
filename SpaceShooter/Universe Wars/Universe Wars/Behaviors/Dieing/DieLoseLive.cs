using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Removes a live from the playerslivestack on dieing
    /// </summary>
    class DieLoseLive : IDieBehavior
    {

        /// <summary>
        /// Remove a live from the players livestack
        /// </summary>
        /// <param name="dieingGameObject">The livinggameobject that is related to the player's lives</param>
        public void Die(LivingGameObject dieingGameObject)
        {

            if (Game1.Player.Lives.Count > 0)
            {

                Live live = Game1.Player.Lives.Pop();
                live.Dispose();

            }

        }
    }
}
