using System;
using Xunit;
using coding_challenge_marygejda;

namespace coding_challenge_marygejda_tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, Orientation.N)]
        [InlineData(0, 0, Orientation.S)]
        [InlineData(0, 0, Orientation.E)]
        [InlineData(0, 0, Orientation.W)]
        [InlineData(51, 0, Orientation.N)]
        [InlineData(0, 51, Orientation.N)]
        public void CanCreateShip(byte x, byte y, Orientation orientation)
        {
            Ship ship = new Ship(x, y, orientation);
            Assert.Equal(x, ship.GetX());
            Assert.Equal(y, ship.GetY());
            Assert.Equal(orientation, ship.GetOrientation());
        }
    }
}
