using System;

namespace Utilities
{
    public class NumbersFeatures
    {
        public static int GetNumberLength(long number)
        {
            return number.ToString().Length;
        }
        public static bool CheckIfNumberDividesByThreeWithoutRemainder(long number)
        {
            bool isNumberDivideByThreeWithoutRemainder = true;

            if (number % 3 != 0)
            {
                isNumberDivideByThreeWithoutRemainder = false;
            }
            return isNumberDivideByThreeWithoutRemainder;
        }

        //public static int GetFirstDigitInNumber(int number)
        //{
        //    int numberLength = GetNumberLength(number);
        //    int power = numberLength - 1;
        //    double divider = Math.Pow(10, power);
        //    return ((int)number / (int)divider);
        //}

    }
}
