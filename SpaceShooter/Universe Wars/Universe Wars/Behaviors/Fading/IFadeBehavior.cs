using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Classes that implement this behavior will make it possible for GameObject to fade out or in.
    /// </summary>
    interface IFadeBehavior
    {

        void Fade(GameObject gameObject);

    }
}
