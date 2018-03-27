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

        [Theory]
        [InlineData(0, 0, Orientation.N)]
        [InlineData(1, 1, Orientation.S)]
        [InlineData(0, 0, Orientation.E)]
        [InlineData(1, 1, Orientation.W)]
        [InlineData(51, 0, Orientation.N)]
        [InlineData(0, 51, Orientation.E)]
        public void CanMoveShipForward(byte x, byte y, Orientation orientation)
        {
            Ship ship = new Ship(x, y, orientation);

            // Check the current position of the ship.
            Assert.Equal(x, ship.GetX());
            Assert.Equal(y, ship.GetY());

            // Move the ship
            ship.MoveForward();

            // Check the new position of the ship
            switch (orientation)
            {
                case Orientation.N:
                    Assert.Equal(y + 1, ship.GetY());
                    break;
                case Orientation.S:
                    Assert.Equal(y - 1, ship.GetY());
                    break;
                case Orientation.E:
                    Assert.Equal(x + 1, ship.GetX());
                    break;
                case Orientation.W:
                    Assert.Equal(x - 1, ship.GetX());
                    break;
                default:
                    break;
            }
        }

        [Theory]
        [InlineData(Orientation.N)]
        [InlineData(Orientation.S)]
        [InlineData(Orientation.E)]
        [InlineData(Orientation.W)]
        public void CanShipTurnRight(Orientation orientation)
        {
            Ship ship = new Ship(0, 0, orientation);

            Assert.Equal(orientation, ship.GetOrientation());

            ship.TurnRight();

            switch (orientation)
            {
                case Orientation.N:
                    Assert.Equal(Orientation.E, ship.GetOrientation());
                    break;
                case Orientation.S:
                    Assert.Equal(Orientation.W, ship.GetOrientation());
                    break;
                case Orientation.E:
                    Assert.Equal(Orientation.S, ship.GetOrientation());
                    break;
                case Orientation.W:
                    Assert.Equal(Orientation.N, ship.GetOrientation());
                    break;
                default:
                    break;
            }
        }

        [Theory]
        [InlineData(Orientation.N)]
        [InlineData(Orientation.S)]
        [InlineData(Orientation.E)]
        [InlineData(Orientation.W)]
        public void CanShipTurnLeft(Orientation orientation)
        {
            Ship ship = new Ship(0, 0, orientation);

            Assert.Equal(orientation, ship.GetOrientation());

            ship.TurnLeft();

            switch (orientation)
            {
                case Orientation.N:
                    Assert.Equal(Orientation.W, ship.GetOrientation());
                    break;
                case Orientation.S:
                    Assert.Equal(Orientation.E, ship.GetOrientation());
                    break;
                case Orientation.E:
                    Assert.Equal(Orientation.N, ship.GetOrientation());
                    break;
                case Orientation.W:
                    Assert.Equal(Orientation.S, ship.GetOrientation());
                    break;
                default:
                    break;
            }
        }
    }
}
