using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1b - Count every time a value increases from its previous using a window of 3 values.");
            StreamReader streamReader = File.OpenText("./DepthData.txt");

            int currentDepth = 0;
            int increaseDepthCount = 0;
            Queue<int> window = new Queue<int>(3);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                if (int.TryParse(line, out int depth))
                {
                    if (window.Count <= 1)
                    {
                        window.Enqueue(depth);
                        continue;
                    }
                    
                    window.Enqueue(depth);
                    int depthWindow = window.Sum();
                    
                    if (currentDepth == 0)
                    {
                        Console.WriteLine($"{depthWindow}: Skipping First Reading");
                    } 
                    else if (currentDepth >= depthWindow)
                    {
                        Console.WriteLine($"{depthWindow}: Decreasing");
                    }
                    else
                    {
                        Console.WriteLine($"{depthWindow}: Increasing (Count: {++increaseDepthCount})");
                    }
                    
                    currentDepth = depthWindow; 
                    window.Dequeue();
                }
            }
        }
    }
}