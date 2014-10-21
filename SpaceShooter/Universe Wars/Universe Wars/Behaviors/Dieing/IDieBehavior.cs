using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Object that implement this interface will do something when a livinggame object dies.
    /// </summary>
    interface IDieBehavior
    {

        void Die(LivingGameObject dieingGameObject);

    }
}
