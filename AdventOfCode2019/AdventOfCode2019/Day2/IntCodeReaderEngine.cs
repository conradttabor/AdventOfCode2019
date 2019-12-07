using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Day2
{
    public class IntCodeReaderEngine
    {
        public static void FindIntCodeSpecificOutput(int[] intCodeProgram, int numberToLookFor)
        {
            var output = 0;

            while (output != numberToLookFor)
            {
                for (int noun = 0; noun < 99; noun++)
                {
                    for (int verb = 0; verb < 99; verb++)
                    {
                        int[] clone = (int[])intCodeProgram.Clone();
                        output = ReadIntCode(clone, noun, verb);

                        if (output == numberToLookFor)
                        {
                            Console.WriteLine($"Noun: {noun} - Verb: {verb} - Result: {output}");
                            Console.WriteLine($"Solution Answer: {(100 * noun) + verb}");
                            break;
                        }
                    }
                    if (output == numberToLookFor)
                        break;
                }
            }
        }

        public static int ReadIntCode(int[] intCodeProgram, int noun, int verb)
        {
            var currentReadPosotion = 0;
            var intCodeProgramLength = intCodeProgram.Length;
            var intCodeProgramCycles = intCodeProgramLength / 4;
            var additionOpCode = 1;
            var multiplyOpCode = 2;
            var exitOpCode = 99;

            // Replace as given in the instructions
            intCodeProgram[1] = noun;
            intCodeProgram[2] = verb;

            for (int i = 1; i <= intCodeProgramCycles; i++)
            {
                var line = new IntCodeLine()
                {
                    Position1 = intCodeProgram[currentReadPosotion],
                    Position2 = intCodeProgram[currentReadPosotion + 1],
                    Position3 = intCodeProgram[currentReadPosotion + 2],
                    Position4 = intCodeProgram[currentReadPosotion + 3]
                };

                if (line.Position1 == additionOpCode)
                {
                    var numberAtPosition2 = intCodeProgram[line.Position2];
                    var numberAtPosition3 = intCodeProgram[line.Position3];
                    var sum = numberAtPosition2 + numberAtPosition3;
                    intCodeProgram[line.Position4] = sum;
                    currentReadPosotion += 4;
                }
                else if (line.Position1 == multiplyOpCode)
                {
                    var numberAtPosition2 = intCodeProgram[line.Position2];
                    var numberAtPosition3 = intCodeProgram[line.Position3];
                    var sum = numberAtPosition2 * numberAtPosition3;
                    intCodeProgram[line.Position4] = sum;
                    currentReadPosotion += 4;
                }
                else if (line.Position1 == exitOpCode)
                {
                    break;
                }
            }

            return intCodeProgram[0];
        }
    }

    public class IntCodeLine
    {
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public int Position3 { get; set; }
        public int Position4 { get; set; }
    }
}
