using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Day3
{
    public class CircuitPoint
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public List<string> Wires { get; set; }
        public bool IsIntersected { get; set; }
        public int DistanceFromCentralPort { get; set; }
        public bool IsCentralPort { get; set; }
        public List<Tuple<string, int>> StepsToGetToThere { get; set; }
    }
}