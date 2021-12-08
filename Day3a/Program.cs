using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 3a - Work out power consumption.");
            StreamReader streamReader = File.OpenText("./Data.txt");

            List<string> data = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                data.Add(line);
            }

            streamReader.Close();

            int entries = data.Count;
            string gammaRate = "", epsilonRate = "";
            
            for (int i = 0; i < data[0].Length; i++)
            {
                int countZeros = data.Count(x => x[i] == '0');
                if (countZeros > (entries / 2))
                {
                    gammaRate += '0';
                    epsilonRate += '1';
                }
                else
                {
                    gammaRate += '1';
                    epsilonRate += '0';
                }
            }

            int gamma = Convert.ToInt32(gammaRate, 2);
            int epsilon = Convert.ToInt32(epsilonRate, 2);
            
            Console.WriteLine($"Gamma Rate: {gammaRate} = {gamma}");
            Console.WriteLine($"Epsilon Rate: {epsilonRate} = {epsilon}");
            Console.WriteLine($"Power Usage: {gamma*epsilon}");
        }
    }
}