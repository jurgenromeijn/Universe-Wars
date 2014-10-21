using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Lets the livingGameObject explode when it dies
    /// </summary>
    class DieExplode : IDieBehavior
    {

        /// <summary>
        /// Lets let the livingGameObject explode.
        /// </summary>
        /// <param name="dieingGameObject">The livingGameObject that has to explode.</param>
        public void Die(LivingGameObject dieingGameObject)
        {

            dieingGameObject.Texture = TextureLoader.GetTexture("explosion");
            dieingGameObject.FlyBehavior = new FlyScrollSpeed(dieingGameObject);
            dieingGameObject.FadeBehavior = new FadeOutLinearSlow();

        }
    }
}
