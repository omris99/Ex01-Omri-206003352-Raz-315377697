using System;
using System.Text;

namespace Ex01_05
{
    public class Program
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

            if (digitsWhichAreSmallerThanFirstDigitString.Length == 0)
            {
                digitsWhichAreSmallerThanFirstDigitString.Append("None");
            }
            Console.WriteLine("- First Digit: {0} | Digits which are smaller than first digit: {1} | Total Count: {2}",
                firstDigitInNumber, digitsWhichAreSmallerThanFirstDigitString.ToString().TrimEnd(','), countOfDigitsWhichAreSmallerThanFirstDigit);
        }
        private bool CheckIfNumberDividesByThreeWithoutRemainder(int number)
        {
            bool isNumberDivideByThreeWithoutRemainder = true;

            if (number % 3 != 0)
            {
                isNumberDivideByThreeWithoutRemainder = false;
            }
            return isNumberDivideByThreeWithoutRemainder;
        }
        private void checkAndPrintHowManyDigitsDividesByThreeWithoutRemainder()
        {
            int number = m_Number;
            int currentDigit;
            bool isDividesByThreeWithoutRemainder;
            int counterOfDigitsWhichDividesByThreeWithoutRemainder = 0;
            StringBuilder digitsDividesByThreeWithoutRemainder = new StringBuilder();
            char seperator = ',';

            while (number > 0)
            {
                currentDigit = number % 10;
                isDividesByThreeWithoutRemainder = CheckIfNumberDividesByThreeWithoutRemainder(currentDigit);
                if (isDividesByThreeWithoutRemainder == true)
                {
                    counterOfDigitsWhichDividesByThreeWithoutRemainder++;
                    digitsDividesByThreeWithoutRemainder.Append(currentDigit.ToString() + seperator);
                }
                number = number / 10;
            }
            Console.WriteLine("- Digits which divides by 3 without remainder: {0} | Total Count: {1}",
                digitsDividesByThreeWithoutRemainder.ToString().TrimEnd(','), counterOfDigitsWhichDividesByThreeWithoutRemainder);

        }

        private void checkAndPrintDifferenceBetweenMaxAndMinDigits()
        {
            int maxDigit;
            int minDigit;
            int differenceBetweenMaxAndMinDigits;
            findMaxAndMinDigitsInNumber(out maxDigit, out minDigit);
            differenceBetweenMaxAndMinDigits = maxDigit - minDigit;
            Console.WriteLine("- Difference Between biggest digit and smallest digit in number: {0}", differenceBetweenMaxAndMinDigits);
        }
        private void findMaxAndMinDigitsInNumber(out int o_MaxDigit, out int o_MinDigit)
        {
            int number = m_Number;
            int currentDigit = number % 10;

            o_MaxDigit = currentDigit;
            o_MinDigit = currentDigit;
            number = number / 10;

            while(number > 0)
            {
                currentDigit = number % 10;
                if(o_MaxDigit < currentDigit)
                {
                    o_MaxDigit = currentDigit;
                }
                if(o_MinDigit >  currentDigit)
                {
                    o_MinDigit = currentDigit;
                }
                number = number / 10;
            }
        }
        public void checkAndPrintMostFrequentDigitAndItsCount()
        {
            int[] digitsCountArray = new int[10];
            int number = m_Number;
            int mostFrequentDigit = 0;
            int biggestCountOfAppearancesRecorded = 0;
            int currentDigit;

            while(number > 0)
            {
                currentDigit = number % 10;
                digitsCountArray[currentDigit]++;
                if(digitsCountArray[currentDigit] > biggestCountOfAppearancesRecorded)
                {
                    biggestCountOfAppearancesRecorded = digitsCountArray[currentDigit];
                    mostFrequentDigit = currentDigit;
                }
                number = number / 10;
            }
            Console.WriteLine("- Most Frequent Digit: {0} | Times counted: {1}", mostFrequentDigit, biggestCountOfAppearancesRecorded);


        }
        public static void Main()
        {
            Program program = new Program();
            program.GetInputFromUser();
            program.PrintStatistics();

            //NumberStatistics numbers = new NumberStatistics();
            //numbers.GetInputFromUser();
            //numbers.PrintStatistics();
        }

        public void GetInputFromUser()
        {
            Console.WriteLine("Hello! Please enter an integer with exactly {0} digits: ", k_NumberValidLength);
            string input = Console.ReadLine();
            bool validInput = false;

            while (validInput == false)
            {
                if (int.TryParse(input, out m_Number) == false)
                {
                    Console.WriteLine("Invalid input: not a valid integer.");
                }
                else if (input.Length != k_NumberValidLength)
                {
                    Console.WriteLine("Invalid input: the number must have exactly {0} digits.", k_NumberValidLength);
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
            checkAndPrintDifferenceBetweenMaxAndMinDigits();
            checkAndPrintMostFrequentDigitAndItsCount();
        }




    }
}
