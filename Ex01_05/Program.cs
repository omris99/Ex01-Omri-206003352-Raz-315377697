using System;
using System.Text;

public class Program
{
    private int m_Number;
    private const int k_NumberValidLength = 8;

    public static void Main()
    {
        Program program = new Program();
        program.GetInputFromUser();
        program.PrintStatistics();
    }

    public void GetInputFromUser()
    {
        bool validInput = false;
        string input;

        Console.WriteLine("Hello! Please enter an integer with exactly {0} digits: ", k_NumberValidLength);
        input = Console.ReadLine();
        while(validInput == false)
        {
            if(int.TryParse(input, out m_Number) == false)
            {
                Console.WriteLine("Invalid input: not a valid integer.");
            }
            else if(input.Length != k_NumberValidLength)
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

    private void checkAndPrintHowManyDigitsAreSmallerThanFirstDigit()
    {
        int number = m_Number;
        int currentDigit;
        int firstDigitInNumber = getFirstDigitInNumber();
        int countOfDigitsWhichAreSmallerThanFirstDigit = 0;
        StringBuilder digitsWhichAreSmallerThanFirstDigitString = new StringBuilder();
        char seperator = ',';

        while(number > 0)
        {
            currentDigit = number % 10;
            if(currentDigit < firstDigitInNumber)
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
        bool digitDividesByThreeWithoutRemainder;
        int counterOfDigitsWhichDividesByThreeWithoutRemainder = 0;
        StringBuilder digitsDividesByThreeWithoutRemainder = new StringBuilder();
        char seperator = ',';

        while(number > 0)
        {
            currentDigit = number % 10;
            digitDividesByThreeWithoutRemainder = (currentDigit % 3 == 0);
            if(digitDividesByThreeWithoutRemainder == true)
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

    public void checkAndPrintMostFrequentDigitAndItsCount()
    {
        int number = m_Number;
        int mostFrequentDigit;
        int biggestCountOfAppearancesRecorded;

        checkMostFrequentDigitAndItsCount(out mostFrequentDigit, out biggestCountOfAppearancesRecorded);
        Console.WriteLine("- Most Frequent Digit: {0} | Times counted: {1}", mostFrequentDigit, biggestCountOfAppearancesRecorded);
    }

    private void checkMostFrequentDigitAndItsCount(out int o_MostFrequentDigit, out int o_BiggestCountOfAppearancesRecorded)
    {
        int currentDigit;
        int currentDigitCount = 0;
        int number = m_Number;
        int digitZeroCount = 0;
        int digitOneCount = 0;
        int digitTwoCount = 0;
        int digitThreeCount = 0;
        int digitFourCount = 0;
        int digitFiveCount = 0;
        int digitSixCount = 0;
        int digitSevenCount = 0;
        int digitEightCount = 0;
        int digitNineCount = 0;

        o_BiggestCountOfAppearancesRecorded = 0;
        o_MostFrequentDigit = 0;
        while(number > 0)
        {
            currentDigit = number % 10;
            if(currentDigit == 0)
            {
                digitZeroCount++;
                currentDigitCount = digitZeroCount;
            }
            else if(currentDigit == 1)
            {
                digitOneCount++;
                currentDigitCount = digitOneCount;
            }
            else if(currentDigit == 2)
            {
                digitTwoCount++;
                currentDigitCount = digitTwoCount;
            }
            else if(currentDigitCount == 3)
            {
                digitThreeCount++;
                currentDigitCount = digitThreeCount;
            }
            else if(currentDigitCount == 4)
            {
                digitFourCount++;
                currentDigitCount = digitFourCount;
            }
            else if(currentDigitCount == 5)
            {
                digitFiveCount++;
                currentDigitCount = digitFiveCount;
            }
            else if(currentDigitCount == 6)
            {
                digitSixCount++;
                currentDigitCount = digitSixCount;
            }
            else if(currentDigitCount == 7)
            {
                digitSevenCount++;
                currentDigitCount = digitSevenCount;
            }
            else if(currentDigitCount == 8)
            {
                digitEightCount++;
                currentDigitCount = digitEightCount;
            }
            else
            {
                digitNineCount++;
                currentDigitCount = digitNineCount;
            }

            if(currentDigitCount > o_BiggestCountOfAppearancesRecorded)
            {
                o_BiggestCountOfAppearancesRecorded = currentDigitCount;
                o_MostFrequentDigit = currentDigit;
            }

            number = number / 10;
        }
    }

    private int getFirstDigitInNumber()
    {
        int power = k_NumberValidLength - 1;
        double divider = Math.Pow(10, power);

        return (m_Number / (int)divider);
    }

    private void findMaxAndMinDigitsInNumber(out int o_MaxDigit, out int o_MinDigit)
    {
        int number = m_Number;
        int currentDigit = number % 10;

        o_MaxDigit = currentDigit;
        o_MinDigit = currentDigit;
        number = number / 10;
        while (number > 0)
        {
            currentDigit = number % 10;
            if (o_MaxDigit < currentDigit)
            {
                o_MaxDigit = currentDigit;
            }

            if (o_MinDigit > currentDigit)
            {
                o_MinDigit = currentDigit;
            }

            number = number / 10;
        }
    }
}
