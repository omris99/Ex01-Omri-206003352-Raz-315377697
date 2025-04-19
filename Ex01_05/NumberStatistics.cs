using System;
using System.Linq;
using System.Text;
using Utilities;

namespace Ex01_05
{
    public class NumberStatistics
    {
        private int m_Number;
        private const int k_NumberValidLength = 8;

        private int getFirstDigitInNumber()
        {
            int power = k_NumberValidLength - 1;
            double divider = Math.Pow(10, power);
            return (m_Number / (int)divider);
        }
        private void checkAndPrintHowManyDigitsAreSmallerThanFirstDigit()
        {
            int number = m_Number;
            int currentDigit;
            //int firstDigitInNumber = NumbersFeatures.GetFirstDigitInNumber(m_Number);
            int firstDigitInNumber = getFirstDigitInNumber();
            int countOfDigitsWhichAreSmallerThanFirstDigit = 0;
            StringBuilder digitsWhichAreSmallerThanFirstDigitString = new StringBuilder();
            char seperator = ',';

            while (number > 0)
            {
                currentDigit = number % 10;
                if (currentDigit < firstDigitInNumber)
                {
                    countOfDigitsWhichAreSmallerThanFirstDigit++;
                    digitsWhichAreSmallerThanFirstDigitString.Append(currentDigit.ToString() + seperator);
                }
                number = number / 10;
            }

            if(digitsWhichAreSmallerThanFirstDigitString.Length == 0)
            {
                digitsWhichAreSmallerThanFirstDigitString.Append("None");
            }
            Console.WriteLine("- First Digit: {0} | Digits which are smaller than first digit: {1} | Total Count: {2}", 
                firstDigitInNumber, digitsWhichAreSmallerThanFirstDigitString.ToString().TrimEnd(','), countOfDigitsWhichAreSmallerThanFirstDigit);
        }

        private void checkAndPrintHowManyDigitsDividesByThreeWithoutRemainder()
        {
            int number = m_Number;
            int currentDigit;
            bool isDividesByThreeWithoutRemainder;
            int counterOfDigitsWhichDividesByThreeWithoutRemainder = 0;
            StringBuilder digitsDividesByThreeWithoutRemainder = new StringBuilder();
            char seperator = ',';

            while(number > 0)
            {
                currentDigit = number % 10;
                isDividesByThreeWithoutRemainder = NumbersFeatures.CheckIfNumberDividesByThreeWithoutRemainder(currentDigit);
                if(isDividesByThreeWithoutRemainder == true)
                {
                    counterOfDigitsWhichDividesByThreeWithoutRemainder++;
                    digitsDividesByThreeWithoutRemainder.Append(currentDigit.ToString() + seperator);
                }
                number = number / 10;
            }
            Console.WriteLine("- Digits which divides by 3 without remainder: {0} | Total Count: {1}",
                digitsDividesByThreeWithoutRemainder.ToString().TrimEnd(','), counterOfDigitsWhichDividesByThreeWithoutRemainder);

        }


        public void GetInputFromUser()
        {
            Console.WriteLine("Hello! Please enter an integer with exactly {0} digits: ", k_NumberValidLength);
            string input = Console.ReadLine();
            bool validInput = false;

            while(validInput == false)
            {
                if(input.Length != k_NumberValidLength)
                {
                    Console.WriteLine("Invalid input: the number must have exactly {0} digits.", k_NumberValidLength);
                }
                else if(int.TryParse(input, out m_Number) == false)
                {
                    Console.WriteLine("Invalid input: not a valid integer.");
                }
                else
                {
                    validInput = true;
                    break;
                }

                Console.WriteLine("Please enter an integer with exactly {0} digits: ", k_NumberValidLength);
                input = Console.ReadLine();
            }
        }

        public void PrintStatistics()
        {
            checkAndPrintHowManyDigitsAreSmallerThanFirstDigit();
            checkAndPrintHowManyDigitsDividesByThreeWithoutRemainder();
            //checkAndPrintDifferenceBetweenMaxAndMinDigits();
            //checkAndPrintMostFrequentDigitAndItsCount();
        }
    }
}
