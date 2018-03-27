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
        }
    }
}
