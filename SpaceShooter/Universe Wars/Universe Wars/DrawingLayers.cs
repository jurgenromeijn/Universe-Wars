using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe_Wars
{
    /// <summary>
    /// This struct contains all the layers that can be used to draw stuff.
    /// This should have been a Enum, but enum's don't allow floating point numbers, so i chose for a struct with constants.
    /// </summary>
    public struct DrawingLayers
    {

        public const float Background = 0;
        public const float Upgrades = 0.1f;
        public const float Projectiles = 0.2f;
        public const float Enemies = 0.3f;
        public const float PlayerShip = 0.5f;
        public const float UI = 0.8f;
        public const float Crosshair = 1;

    }
}
