using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Don't fade in or out.
    /// </summary>
    class DoNotFade : IFadeBehavior
    {

        /// <summary>
        /// Don't fade, just stay the way you are.
        /// </summary>
        /// <param name="gameObject">The gameObject that doesn't have to fade</param>
        public void Fade(GameObject gameObject)
        {
            
            //do nothing

        }
    }
}
