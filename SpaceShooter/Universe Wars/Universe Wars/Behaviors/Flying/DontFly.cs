using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Lets the flyingGameObject not fly, kind of sad really.
    /// </summary>
    class DontFly : IFlyBehavior
    {

        /// <summary>
        /// Just hang around for a bit.
        /// </summary>
        public void Fly()
        {
            //just hang around and do nothing except use our precious memory :(
        }

    }
}
