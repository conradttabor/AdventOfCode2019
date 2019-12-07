using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class FuelCalculatorEngine
    {
        public static void CalculateTotalFuelRequirement(List<int> moduleMasses)
        {
            var requirement = moduleMasses.Select(x => CalculateRequiredFuelMass(x)).Sum();
            Console.WriteLine($"Fuel Requirement: {requirement}");
            var requirementIncludingFuel = moduleMasses.Select(x => CalculateRequiredFuelMassIncludingFuelMass(x)).Sum();
            Console.WriteLine($"Fuel Requirement Including Fuel: {requirementIncludingFuel}");
        }
        public static int CalculateRequiredFuelMass(double moduleMass)
        {
            return (int)Math.Floor(moduleMass / 3) - 2;
        }

        public static int CalculateRequiredFuelMassIncludingFuelMass(double moduleMass)
        {
            var initialFuelRequired = CalculateRequiredFuelMass(moduleMass);
            var fuelNeededForFuel = CalculateFuelNeededForFuel(initialFuelRequired);
            return initialFuelRequired + fuelNeededForFuel;
        }

        public static int CalculateFuelNeededForFuel(double initialFuel)
        {
            var currentRequirement = CalculateRequiredFuelMass(initialFuel);
            var totalRequirement = currentRequirement;

            while (currentRequirement > 0)
            {
                currentRequirement = CalculateRequiredFuelMass(currentRequirement);
                if (currentRequirement > 0)
                    totalRequirement += currentRequirement;
            }

            return totalRequirement;
        }
    }
}
