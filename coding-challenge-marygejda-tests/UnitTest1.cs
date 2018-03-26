using System;
using Xunit;
using coding_challenge_marygejda;

namespace coding_challenge_marygejda_tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, Orientation.N)]
        public void Test1(byte x, byte y, Orientation orientation)
        {
            Ship ship = new Ship(x, y, orientation);
            Assert.Equal(x, ship.GetX());
        }
    }
}
