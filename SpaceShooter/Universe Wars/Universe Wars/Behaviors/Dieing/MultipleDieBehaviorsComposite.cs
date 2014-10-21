using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Makes sure we can let multiple things happen when a living game object dies.
    /// </summary>
    class MultipleDieBehaviorsComposite : IDieBehavior
    {

        private List<IDieBehavior> _dieBehaviors = new List<IDieBehavior>();

        public List<IDieBehavior> DieBehaviors
        {
            get { return _dieBehaviors; }
        }

        /// <summary>
        /// Loop through all the die behaviors and let them do their thing.
        /// </summary>
        /// <param name="dieingGameObject">The LivingGameObject that is dieing.</param>
        public void Die(LivingGameObject dieingGameObject)
        {

            foreach (IDieBehavior dieBehavior in _dieBehaviors)
            {

                dieBehavior.Die(dieingGameObject);

            }

        }
    }
}
