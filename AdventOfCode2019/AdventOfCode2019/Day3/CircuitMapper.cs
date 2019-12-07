using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class CircuitMapper
    {
        public static void MapCircuits(List<Wire> wires)
        {
            var circuitBoard = new Circuit();
            var intersections = new List<CircuitPoint>();

            foreach (var wire in wires)
            {
                var currentX = 0;
                var currentY = 0;
                var stepCount = 0;
                for (int i = 0; i < wire.Routes.Length; i++)
                {
                    var route = wire.Routes[i];
                    
                    for (int j = 0; j < route.Distance; j++)
                    {                        
                        switch (route.Direction)
                        {
                            case 'U':
                                currentY++;
                                break;
                            case 'D':
                                currentY--;
                                break;
                            case 'L':
                                currentX--;
                                break;
                            case 'R':
                                currentX++;
                                break;
                        }
                        stepCount++;
                        if (currentX == 0 && currentY == 0)
                            continue;
                        var circuitPointExists = circuitBoard.CircuitBoard.ContainsKey(new Tuple<int, int>(currentX, currentY));
                        if (circuitPointExists)
                        {
                            var currentCircuit = circuitBoard.CircuitBoard.First(x => x.Key.Item1 == currentX && x.Key.Item2 == currentY);
                            if (!currentCircuit.Value.Wires.Contains(wire.Name))
                            {
                                currentCircuit.Value.Wires.Add(wire.Name);
                                currentCircuit.Value.IsIntersected = true;
                                currentCircuit.Value.StepsToGetToThere.Add(new Tuple<string, int>(wire.Name, stepCount));
                                intersections.Add(currentCircuit.Value);
                            }                            
                        }
                        else
                        {
                            circuitBoard.CircuitBoard.Add(new Tuple<int, int>(currentX, currentY), new CircuitPoint()
                            {
                                DistanceFromCentralPort = CalculateManhattanDistanceFromCentralPort(currentX, currentY),
                                IsCentralPort = false,
                                IsIntersected = false,
                                Wires = new List<string>() { wire.Name },
                                XAxis = currentX,
                                YAxis = currentY,
                                StepsToGetToThere = new List<Tuple<string, int>>()
                                {
                                    new Tuple<string, int>(wire.Name, stepCount)
                                }
                            });
                        }
                    }
                }
            }
            Console.WriteLine($"Distance from central port: {intersections.Min(x => x.DistanceFromCentralPort)}");
            
            Console.WriteLine($"Minimum steps: {intersections.Min(x => x.StepsToGetToThere.Sum(y => y.Item2))}");            
        }

        private static int CalculateManhattanDistanceFromCentralPort(int x, int y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}