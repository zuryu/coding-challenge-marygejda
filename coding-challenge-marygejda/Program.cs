using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_challenge_marygejda
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assume input from a file. Todo: Check if this is the case.
            string[] inputLines = File.ReadAllLines(@"D:\Work\StratumFive\Input.txt");

            // Get the size of the map
            string[] mapXY = inputLines[0].Split(' ');
            Byte.TryParse(mapXY[0], out byte mapX);
            Byte.TryParse(mapXY[1], out byte mapY);

            for (int i = 1; i < inputLines.Length; i += 2)
            {
                if (String.IsNullOrWhiteSpace(inputLines[i]))
                {
                    i--; // Move i back 1 because i will have 2 added to it at the start of the next loop. This allows us to skip blank lines.
                    continue;
                }

                // Get the ship details
                string[] shipLine = inputLines[i].Split(' ');
                Byte.TryParse(shipLine[0], out byte x);
                Byte.TryParse(shipLine[1], out byte y);
                Enum.TryParse(shipLine[2], out Orientation orientation);
                Ship ship = new Ship(x, y, orientation);


                // for each instruction
                string instructions = inputLines[i + 1];
                foreach (char instruction in instructions)
                {
                    if (instruction == 'F')
                    {
                        if (CanMoveForward(ship, mapX, mapY))
                        {
                            ship.MoveForward();
                        }
                        else
                        {
                            ship.BecomeLost();
                            break;
                        }
                    }
                    else if (instruction == 'R')
                    {
                        ship.TurnRight();
                    }
                    else if (instruction == 'L')
                    {
                        ship.TurnLeft();
                    }                    
                }

                // Print the final details of the ship.
                Console.Write(ship.GetX() + " " + ship.GetY() + " " + ship.GetOrientation());
                if (ship.IsLost())
                {
                    Console.WriteLine(" LOST");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        /// <summary>
        /// Checks if a ship can move forward without going off the edge of the map.
        /// </summary>
        /// <param name="ship">The ship to check.</param>
        /// <param name="xMax">The maximum x size of the map.</param>
        /// <param name="yMax">The maximum y size of the map.</param>
        /// <returns>True if the ship can move forward without going off the map, false otherwise.</returns>
        public static bool CanMoveForward(Ship ship, byte xMax, byte yMax)
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
