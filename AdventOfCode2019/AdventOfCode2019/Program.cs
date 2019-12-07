using AdventOfCode2019.Day1;
using AdventOfCode2019.Day2;
using AdventOfCode2019.Day6;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------DAY1----------");
            var day1Inputs = GetDay1Inputs("../../../Day1/Day1Input.txt");
            FuelCalculatorEngine.CalculateTotalFuelRequirement(day1Inputs);
            Console.WriteLine("----------DAY2----------");
            var day2Inputs = GetDay2Inputs("../../../Day2/Day2Input.txt");
            int[] clone1 = (int[])day2Inputs.Clone();
            int[] clone2 = (int[])day2Inputs.Clone();
            Console.WriteLine($"Output: {IntCodeReaderEngine.ReadIntCode(clone1, 12, 2)}");
            IntCodeReaderEngine.FindIntCodeSpecificOutput(clone2, 19690720);
            Console.WriteLine("----------DAY6----------");
            var day6Inputs = GetDay6Inputs("../../../Day6/Day6Input.txt");
            var mapEngine = new UniversalOrbitalMapEngine(day6Inputs);
            mapEngine.MapOrbits();
        }

        public static List<int> GetDay1Inputs(string filePath)
        {
            var inputs = new List<int>();
            Stream stream = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                inputs.Add(int.Parse(line));
            }
            return inputs;
        }

        public static int[] GetDay2Inputs(string filePath)
        {            
            Stream stream = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            var input = reader.ReadLine();
            var myString = input.Split(',');
            var inputs = new int[myString.Length];
            for (int i = 0; i < myString.Length; i++)
            {
                inputs[i] = int.Parse(myString[i]);
            }
            
            return inputs;
        }

        public static List<Tuple<string, string>> GetDay6Inputs(string filePath)
        {
            var inputs = new List<Tuple<string, string>>();
            Stream stream = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var split = line.Split(')');
                inputs.Add(new Tuple<string, string>(split[0], split[1].TrimEnd(',')));
            }
            return inputs;
        }
    }
}
