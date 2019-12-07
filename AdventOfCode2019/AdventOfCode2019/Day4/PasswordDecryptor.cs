using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Day4
{
    public class PasswordDecryptor
    {
        public static void TotalDecryptionOptions(int startingNumber, int endingNumber)
        {
            var viablePasswordCount = 0;
            var strictViablePasswordCount = 0;

            IsViableStrictPassword(112233);
            IsViableStrictPassword(123444);
            IsViableStrictPassword(111122);

            for (int i = startingNumber; i <= endingNumber; i++)
            {
                if (IsViablePassword(i))
                    viablePasswordCount++;
                if (IsViableStrictPassword(i))
                    strictViablePasswordCount++;
            }

            Console.WriteLine($"Viable Options: {viablePasswordCount}");
            Console.WriteLine($"Strict Viable Options: {strictViablePasswordCount}");
        }

        public static bool IsViableStrictPassword(int number)
        {
            var intArray = GetIntArray(number);
            var doubleCount = 0;
            var guarantee = false;

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                    return false;
                if (i == 0)
                {
                    if (intArray[i] == intArray[i + 1] && intArray[i] != intArray[i + 2])
                    {
                        guarantee = true;
                    }
                }
                else if (i != 0 && i < intArray.Length - 2)
                {
                    if (intArray[i] == intArray[i + 1] && intArray[i] != intArray[i + 2] && intArray[i] != intArray[i-1])
                    {
                        guarantee = true;
                    }
                }
                else if (i == intArray.Length - 2)
                {
                    if (intArray[i] == intArray[i + 1] && intArray[i] != intArray[i - 1])
                    {
                        guarantee = true;
                    }
                }
            }

            if (guarantee)
                return true;

            return false;
        }

        private static bool IsViablePassword(int number)
        {
            var intArray = GetIntArray(number);
            var doubleCount = 0;

            for (int i = 0; i < intArray.Length-1; i++)
            {
                if (intArray[i] > intArray[i + 1])
                    return false;
                if (intArray[i] == intArray[i + 1])
                    doubleCount++;
                
            }
            
            if (doubleCount == 0)
                return false;

            return true;
        }

        private static int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}
