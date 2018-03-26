using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge_marygejda
{
    class Ship
    {
        private byte x;
        private byte y;
        private Orientation orientation;

        public Ship(byte x, byte y, Orientation orientation)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
        }
    }

    public enum Orientation { N, E, S, W }
}
