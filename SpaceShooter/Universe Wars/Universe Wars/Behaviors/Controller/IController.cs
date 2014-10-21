using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// Any Class implementing the IController interface should be able to controll the playership and the crosshair
    /// </summary>
    interface IController
    {

        void UpdateState();
        void CheckMovement(PlayerShip ship);
        void UpdateCrosshair(PlayerShip ship, Crosshair crosshair);
        void CheckFire(PlayerShip ship);

    }
}
