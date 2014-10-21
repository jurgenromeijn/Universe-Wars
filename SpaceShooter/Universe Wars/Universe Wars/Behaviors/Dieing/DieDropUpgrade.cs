using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Gives the Livinggameobject a 1 in 3 chance to drop a random upgrade
    /// </summary>
    class DieDropUpgrade : IDieBehavior
    {

        /// <summary>
        /// Try to drop an upgrade.
        /// </summary>
        /// <param name="dieingGameObject">the livinggameobject that has to drop the upgrade</param>
        public void Die(LivingGameObject dieingGameObject)
        {

            Random rand = new Random();

            if (rand.Next(4) == 0)
            {

                Upgrade upgrade;

                switch (rand.Next(3))
                {
                    case 0:
                        upgrade = new Laser(dieingGameObject.Game);
                        break;
                    case 1:
                        upgrade = new RocketLauncher(dieingGameObject.Game);
                        break;
                    default:
                        upgrade = new GuidedMissileLauncher(dieingGameObject.Game);
                        break;
                }

                upgrade.Position = dieingGameObject.Position;

            }

        }

    }

}
