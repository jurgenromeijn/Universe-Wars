using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// This Composition makes it possible for FlyingGameObjects to have multiple flyBehaviors.
    /// </summary>
    class MultipleFlyBehaviorComposite : IFlyBehavior
    {

        private List<IFlyBehavior> _flyBehaviors = new List<IFlyBehavior>();

        public List<IFlyBehavior> FlyBehaviors
        {
            get { return _flyBehaviors; }
        }

        /// <summary>
        /// Loop through all the flyBehaviors and let them all do their thing.
        /// </summary>
        public void Fly()
        {

            foreach (IFlyBehavior flyBehavior in _flyBehaviors)
            {

                flyBehavior.Fly();
                
            }

        }
    }
}
