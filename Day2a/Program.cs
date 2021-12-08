using System;
using System.IO;

namespace Day2a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 2a - Determine the position of the sub.");
            StreamReader streamReader = File.OpenText("./MovementData.txt");

            int currentDepth = 0;
            int currentHorizontalPosition = 0;

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                if (int.TryParse(line.Split(' ')[1], out int distance))
                {
                    switch (line[0])
                    {
                        case 'f':
                            currentHorizontalPosition += distance;
                            break;
                        case 'd':
                            currentDepth += distance;
                            break;
                        case 'u':
                            currentDepth -= distance;
                            
                            if (currentDepth < 0)
                            {
                                Console.WriteLine("Subs cant fly...");
                                currentDepth = 0;
                            }
                            break;
                        default:
                            Console.WriteLine($"Unknown Direction {line[0]}");
                            break;
                    }
                }
            }
            
            Console.WriteLine($"Depth: {currentDepth} x Horizontal: {currentHorizontalPosition} = {currentDepth*currentHorizontalPosition}");
        }
    }
}