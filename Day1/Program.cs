using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 - Count every time a value increases from its previous.");
            StreamReader streamReader = File.OpenText("./DepthData.txt");

            int currentDepth = 0;
            int increaseDepthCount = 0;

            while(!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if(string.IsNullOrWhiteSpace(line)) continue;
                
                if (int.TryParse(line, out int readInDepth))
                {
                    if (currentDepth == 0)
                    {
                        Console.WriteLine($"{readInDepth}: Skipping First Reading");
                    } 
                    else if (currentDepth >= readInDepth)
                    {
                        Console.WriteLine($"{readInDepth}: Decreasing");
                    }
                    else
                    {
                        Console.WriteLine($"{readInDepth}: Increasing (Count: {++increaseDepthCount})");
                    }
                    
                    currentDepth = readInDepth; 
                }
            }
            
            streamReader.Close();
        }
    }
}