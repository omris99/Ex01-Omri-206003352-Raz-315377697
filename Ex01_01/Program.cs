using System;

class Program
{
    private string[] m_BinaryNumbersGroup = new string[k_GroupSize];
    private const int k_GroupSize = 4;
    private const int k_NumberLength = 7;
    
    public static void Main()
    {
        Program program = new Program();

        program.GetInputFromUser();
        program.PrintNumbersInDescendingOrderAndStatistics();
    }

    public void GetInputFromUser()
    {
        string inputRequest = String.Format("Hello, please enter {0} Binary Numbers with exactly {1} digits: ", k_GroupSize, k_NumberLength);
        string binaryNumberString;

        Console.WriteLine(inputRequest);
        for (int i = 0; i < k_GroupSize; i++)
        {
            binaryNumberString = Console.ReadLine();
            while(checkInputValidation(binaryNumberString) == false)
            {
                Console.WriteLine("Error! Try again.");
                binaryNumberString = Console.ReadLine();
            }

            m_BinaryNumbersGroup[i] = binaryNumberString;
        }
    }

    public void PrintNumbersInDescendingOrderAndStatistics()
    {
        printNumbersInDescendingOrder();
        printStatistics();
    }

    private void printStatistics()
    {
        calculateAndPrintDecimalAverage();
        findAndPrintTheLongestOnesSequenceLegnth();
        findAndPrintNumberOfExchangesBetweenZeroAndOneForEachNumber();
        findAndPrintNumberWithMostOnesCount();
        countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers();
    }

    private void printNumbersInDescendingOrder()
    {
        char seperator = ',';
        int lastNumberInGroup = k_GroupSize - 1;

        sortInDescendingOrderBinaryNumbersGroup();
        Console.Write("The input numbers in their decimal value and in descending order: ");
        for (int i = 0; i < k_GroupSize; i++)
        {
            if (i == lastNumberInGroup)
            {
                seperator = ' ';
            }

            string toPrint = String.Format("{0}{1} ", getDecimalValue(m_BinaryNumbersGroup[i]), seperator);
            Console.Write(toPrint);
        }

        Console.WriteLine();
    }

    private void calculateAndPrintDecimalAverage()
    {
        double decimalAverageOfAllBinaryNumbers = 0;
        double sumOfAllNumbersInDecimal = 0;

        for (int i = 0; i < k_GroupSize; i++)
        {
            sumOfAllNumbersInDecimal += getDecimalValue(m_BinaryNumbersGroup[i]);
        }

        decimalAverageOfAllBinaryNumbers = sumOfAllNumbersInDecimal / k_GroupSize;
        Console.WriteLine("Average: {0}", decimalAverageOfAllBinaryNumbers.ToString());
    }

    private void countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers()
    {
        int onesCounter = 0;

        for(int i = 0; i < k_GroupSize; i++)
        {
            onesCounter += getQuantityOfOnesInNumber(m_BinaryNumbersGroup[i]);
        }

        Console.WriteLine("Total number Of ones counted: {0}", onesCounter);
    }

    private int getQuantityOfOnesInNumber(string i_BinaryNumber)
    {
        int quantityOfOnes = 0;

        for(int i = 0; i < k_NumberLength; i++)
        {
            if(i_BinaryNumber[i] == '1')
            {
                quantityOfOnes++;
            }
        }

        return quantityOfOnes;
    }

    private void findAndPrintNumberWithMostOnesCount()
    {
        int maxOnesCounted = 0;
        int currentOnesCount = 0;
        string numberWithTheMostOnesCount = "0";

        for(int i = 0; i < k_GroupSize; i++)
        {
            currentOnesCount = getQuantityOfOnesInNumber(m_BinaryNumbersGroup[i]);
            if(currentOnesCount > maxOnesCounted)
            {
                maxOnesCounted = currentOnesCount;
                numberWithTheMostOnesCount = m_BinaryNumbersGroup[i];
            }
        }

        Console.WriteLine("\nNumber with the most ones: {0}, (Binary: {1})", getDecimalValue(numberWithTheMostOnesCount), numberWithTheMostOnesCount.ToString());
    }

    private void findAndPrintNumberOfExchangesBetweenZeroAndOneForEachNumber()
    {
        int numberOfExchanges = 0;
        char seperator = ',';
        int lastNumberInGroup = k_GroupSize - 1;

        Console.Write("Number of exchanges: ");
        for(int i = 0; i < k_GroupSize; i++)
        {
            if(i == lastNumberInGroup)
            {
                seperator = ' ';
            }

            numberOfExchanges = getQuantityOfExchangesBetweenZeroesAndOnes(m_BinaryNumbersGroup[i]);
            Console.Write("({0}) {1}{2} ", m_BinaryNumbersGroup[i].ToString(), numberOfExchanges, seperator);
        }
    }

    private int getQuantityOfExchangesBetweenZeroesAndOnes(string i_BinaryNumber)
    {
        int quantityOfExchangesBetweenZeroesAndOnes = 0;
        int currentDigit;
        int prevDigit = -1;

        for(int i = 0; i < k_NumberLength; i++)
        {
            if(i_BinaryNumber[i] == '1')
            {
                currentDigit = 1;
                if (prevDigit == 0)
                {
                    quantityOfExchangesBetweenZeroesAndOnes++;
                }
            }
            else
            {
                currentDigit = 0;
                if(prevDigit == 1)
                {
                    quantityOfExchangesBetweenZeroesAndOnes++;
                }
            }

            prevDigit = currentDigit;
        }

        return quantityOfExchangesBetweenZeroesAndOnes;
    }

    private void findAndPrintTheLongestOnesSequenceLegnth()
    {
        int currentOnesSequenceLength;
        int longestOnesSequenceLength = 0;
        string numberWithTheLongestSequenceLength = "";

        for(int i = 0; i < k_GroupSize; i++)
        {
            currentOnesSequenceLength = getLengthOfLongestOnesSequence(m_BinaryNumbersGroup[i]);
            if(currentOnesSequenceLength > longestOnesSequenceLength)
            {
                longestOnesSequenceLength = currentOnesSequenceLength;
                numberWithTheLongestSequenceLength = m_BinaryNumbersGroup[i].ToString();
            }
        }

        Console.WriteLine("Longest ones sequence length: {0} (in number {1})", longestOnesSequenceLength, numberWithTheLongestSequenceLength);
    }

    private int getLengthOfLongestOnesSequence(string i_BinaryNumber)
    {
        int totalLegnthOfLongestOnesSequence = 0;
        int currentLegnthOfLongestOnesSequence = 0;
        int previousDigit = -1;
        int currentDigit;
        int leastSignificantBit = k_NumberLength - 1;

        for(int i = 0; i < k_NumberLength; i++)
        {
            if(i_BinaryNumber[i] == '1')
            {
                currentDigit = 1;
                currentLegnthOfLongestOnesSequence++;
                if(previousDigit == 1 && i == leastSignificantBit)
                {
                    checkAndUpdateLengthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                    currentLegnthOfLongestOnesSequence = 0;
                }
            }
            else
            {
                currentDigit = 0;
                if(previousDigit == 1)
                {
                    checkAndUpdateLengthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                }

                currentLegnthOfLongestOnesSequence = 0;
            }

            previousDigit = currentDigit;
        }

        return totalLegnthOfLongestOnesSequence;
    }

    private bool checkAndUpdateLengthOfLongestOnesSequence(int i_CurrentLengthOfLongestOnesSequence, ref int io_TotalLengthOfLongestOnesSequence)
    {
        bool currentLengthOfLongestOnesSequenceIsTheBiggest = i_CurrentLengthOfLongestOnesSequence > io_TotalLengthOfLongestOnesSequence;

        if(currentLengthOfLongestOnesSequenceIsTheBiggest == true)
        {
            io_TotalLengthOfLongestOnesSequence = i_CurrentLengthOfLongestOnesSequence;
        }

        return currentLengthOfLongestOnesSequenceIsTheBiggest;
    }

    private int getDecimalValue(string i_BinaryNumberString)
    {
        int power = 0;
        int decimalValue = 0;

        for(int i = 0; i < k_NumberLength; i++)
        {
            power = k_NumberLength - i - 1;
            if(i_BinaryNumberString[i] != '0')
            {
                decimalValue += (int)Math.Pow(2, power);
            }
        }

        return decimalValue;
    }

    private bool checkInputValidation(string i_Input)
    {
        bool validation = (i_Input.Length == k_NumberLength) && (checkIfAllDigitsInNumberAreBinary(i_Input) == true);

        return validation;
    }

    private bool checkIfAllDigitsInNumberAreBinary(string i_Input)
    {
        bool digitsInNumberAreBinary = true;

        for (int i = 0; i < i_Input.Length; i++)
        {
            if (i_Input[i] != '0' && i_Input[i] != '1')
            {
                digitsInNumberAreBinary = false;
            }
        }

        return digitsInNumberAreBinary;
    }

    private void sortInDescendingOrderBinaryNumbersGroup()
    {
        bool needToSwapBetweenNumbersInArray;

        for (int i = 0; i < k_GroupSize; i++)
        {
            for (int j = 0; j < k_GroupSize - i - 1; j++)
            {
                needToSwapBetweenNumbersInArray = getDecimalValue(m_BinaryNumbersGroup[j]) < getDecimalValue(m_BinaryNumbersGroup[j + 1]);
                if (needToSwapBetweenNumbersInArray == true)
                {
                    swapStringsInArray(j, j + 1);
                }
            }
        }
    }

    private void swapStringsInArray(int i_FirstString, int i_SecondString)
    {
        string stringKeeper;

        stringKeeper = m_BinaryNumbersGroup[i_FirstString];
        m_BinaryNumbersGroup[i_FirstString] = m_BinaryNumbersGroup[i_SecondString];
        m_BinaryNumbersGroup[i_SecondString] = stringKeeper;
    }
}
