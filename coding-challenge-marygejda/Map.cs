using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge_marygejda
{
    /// <summary>
    /// This class represents a map.
    /// </summary>
    public class Map
    {
        private byte xMax;
        private byte yMax;
        HashSet<string> lostMarkers;

        /// <summary>
        /// Creates a Map object.
        /// </summary>
        /// <param name="xMax">The maximum x coordinate.</param>
        /// <param name="yMax">The maximum y coordinate.</param>
        public Map(byte xMax, byte yMax)
        {
            this.xMax = xMax;
            this.yMax = yMax;
            lostMarkers = new HashSet<string>();
        }

        /// <summary>
        /// Checks if a lost marker is set at the given location.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="orientation">The orientation of the ship.</param>
        /// <returns>True is there is a lost marker at that location, false otherwise.</returns>
        public bool IsMarkerSet(byte x, byte y, Orientation orientation)
        {
            return lostMarkers.Contains(x + " " + y + " " + orientation);
        }

        /// <summary>
        /// Sets a lost marker at the given location.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="orientation">The orientation of the ship.</param>
        public void SetLostMarker(byte x, byte y, Orientation orientation)
        {
            lostMarkers.Add(x + " " + y + " " + orientation);
        }

        /// <summary>
        /// Returns the maximum x coordinate of the map.
        /// </summary>
        /// <returns>The maximum x coordinate of the map.</returns>
        public byte GetXMax()
        {
            return xMax;
        }

        /// <summary>
        /// Returns the maximum y coordinate of the map.
        /// </summary>
        /// <returns>The maximum y coordinate of the map.</returns>
        public byte GetYMax()
        {
            return yMax;
        }

        /// <summary>
        /// Checks if a ship can move forward without going off the edge of the map.
        /// </summary>
        /// <param name="ship">The ship to check.</param>
        /// <returns>True if the ship can move forward without going off the map, false otherwise.</returns>
        public bool CanMoveForward(Ship ship)
        {
            if (ship.GetX() == 0 && ship.GetOrientation() == Orientation.W)
            {
                return false;
            }
            if (ship.GetX() == xMax && ship.GetOrientation() == Orientation.E)
            {
                return false;
            }
            if (ship.GetY() == 0 && ship.GetOrientation() == Orientation.S)
            {
                return false;
            }
            if (ship.GetY() == yMax && ship.GetOrientation() == Orientation.N)
            {
                return false;
            }
            return true;
        }
    }
}
