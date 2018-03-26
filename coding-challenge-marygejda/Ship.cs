namespace coding_challenge_marygejda
{
    /// <summary>
    /// This class represents a ship.
    /// </summary>
    public class Ship
    {
        private byte x;
        private byte y;
        private Orientation orientation;

        /// <summary>
        /// Creates a ship object.
        /// </summary>
        /// <param name="x">The initial x coordinate of the ship.</param>
        /// <param name="y">The initial y coordinate of the ship.</param>
        /// <param name="orientation">The initial orientation of the ship.</param>
        public Ship(byte x, byte y, Orientation orientation)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
        }

        /// <summary>
        /// Returns the x coordinate of the ship.
        /// </summary>
        /// <returns>The x coordinate of the ship.</returns>
        public byte GetX()
        {
            return x;
        }

        /// <summary>
        /// Returns the y coordinate of the ship.
        /// </summary>
        /// <returns>The y coordinate of the ship.</returns>
        public byte GetY()
        {
            return y;
        }

        /// <summary>
        /// Returns the orientation of the ship.
        /// </summary>
        /// <returns>The orientation of the ship.</returns>
        public Orientation GetOrientation()
        {
            return orientation;
        }
    }

    /// <summary>
    /// This enum is the possible orientations of a ship.
    /// </summary>
    public enum Orientation { N, E, S, W }
}
