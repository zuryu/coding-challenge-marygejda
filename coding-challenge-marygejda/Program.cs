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
            Map map = new Map(mapX, mapY);

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
                        if (map.CanMoveForward(ship))
                        {
                            ship.MoveForward();
                        }
                        else
                        {
                            if (!map.IsMarkerSet(ship.GetX(), ship.GetY(), ship.GetOrientation()))
                            {
                                map.SetLostMarker(ship.GetX(), ship.GetY(), ship.GetOrientation());
                                ship.BecomeLost();
                                break;
                            }
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
                    Console.Write(" LOST");
                }
                Console.WriteLine();
            }
        }
    }
}
