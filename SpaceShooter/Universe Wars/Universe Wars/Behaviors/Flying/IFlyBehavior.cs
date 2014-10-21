using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Classes that implement this Interface have to be able to let a FlyingGameObject fly.
    /// </summary>
    interface IFlyBehavior
    {

        void Fly();

    }
}
