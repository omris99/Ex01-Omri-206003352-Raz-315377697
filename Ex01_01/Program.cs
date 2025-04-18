//TODO:
//1. change bubble sort
//2. create numbers validation function
//3. think on another input and put in inputs.txt

using System;

namespace Ex01_01
{
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

        private bool checkInputValidation(string i_Input)
        {
            bool validation = true;

            if (i_Input.Length != k_NumberLength)
            {
                validation = false;
            }
            else if (checkIfAllDigitsInNumberAreBinary(i_Input) == false)
            {
                validation = false;
            }
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



        private void countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers()
        {
            int onesCounter = 0;

            for (int i = 0; i < k_GroupSize; i++)
            {
                onesCounter += getQuantityOfOnesInNumber(m_BinaryNumbersGroup[i]);
            }
            Console.WriteLine("Total number Of ones counted: {0}", onesCounter);
        }

        private int getQuantityOfOnesInNumber(string i_BinaryNumber)
        {
            int quantityOfOnes = 0;

            for (int i = 0; i < k_NumberLength; i++)
            {
                if (i_BinaryNumber[i] == '1')
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
            for (int i = 0; i < k_GroupSize; i++)
            {
                currentOnesCount = getQuantityOfOnesInNumber(m_BinaryNumbersGroup[i]);
                if (currentOnesCount > maxOnesCounted)
                {
                    maxOnesCounted = currentOnesCount;
                    numberWithTheMostOnesCount = m_BinaryNumbersGroup[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Number with the most ones: {0}, (Binary: {1})", getDecimalValue(numberWithTheMostOnesCount), numberWithTheMostOnesCount.ToString());
        }


        private void findAndPrintNumberOfExchangesBetweenZeroAndOneForEachNumber()
        {
            int numberOfExchanges = 0;
            char seperator = ',';
            int lastNumberInGroup = k_GroupSize - 1;
            Console.Write("Number of exchanges: ");
            for (int i = 0; i < k_GroupSize; i++)
            {
                if (i == lastNumberInGroup)
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
            int currentDigit; //change digit to bit
            int prevDigit = -1;
            for (int i = 0; i < k_NumberLength; i++)
            {
                if (i_BinaryNumber[i] == '1')
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
                    if (prevDigit == 1)
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
            for (int i = 0; i < k_GroupSize; i++)
            {
                currentOnesSequenceLength = getLegnthOfLongestOnesSequence(m_BinaryNumbersGroup[i]);
                if (currentOnesSequenceLength > longestOnesSequenceLength)
                {
                    longestOnesSequenceLength = currentOnesSequenceLength;
                    numberWithTheLongestSequenceLength = m_BinaryNumbersGroup[i].ToString();
                }
            }
            Console.WriteLine("Longest ones sequence length: {0} (in number {1})", longestOnesSequenceLength, numberWithTheLongestSequenceLength);
        }
        private int getLegnthOfLongestOnesSequence(string i_BinaryNumber)
        {
            int totalLegnthOfLongestOnesSequence = 0;
            int currentLegnthOfLongestOnesSequence = 0;
            int previousDigit = -1;
            int currentDigit;
            int leastSignificantBit = k_NumberLength - 1;

            for (int i = 0; i < k_NumberLength; i++)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    currentDigit = 1;
                    currentLegnthOfLongestOnesSequence++;
                    if (previousDigit == 1 && i == leastSignificantBit)
                    {
                        checkAndUpdateLegnthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                        currentLegnthOfLongestOnesSequence = 0;
                    }
                }
                else
                {
                    currentDigit = 0;
                    if (previousDigit == 1)
                    {
                        checkAndUpdateLegnthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                    }

                    currentLegnthOfLongestOnesSequence = 0;
                }
                previousDigit = currentDigit;
            }
            return totalLegnthOfLongestOnesSequence;
        }

        private bool checkAndUpdateLegnthOfLongestOnesSequence(int i_CurrentLegnthOfLongestOnesSequence, ref int io_TotalLegnthOfLongestOnesSequence)
        {
            bool awnser = false;
            if (i_CurrentLegnthOfLongestOnesSequence > io_TotalLegnthOfLongestOnesSequence)
            {
                io_TotalLegnthOfLongestOnesSequence = i_CurrentLegnthOfLongestOnesSequence;
                awnser = true;
            }
            return awnser;
        }

        private void printStatistics()
        {
            calculateAndPrintDecimalAverage();
            findAndPrintTheLongestOnesSequenceLegnth();
            findAndPrintNumberOfExchangesBetweenZeroAndOneForEachNumber();
            findAndPrintNumberWithMostOnesCount();
            countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers();
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

        private int getDecimalValue(string i_BinaryNumberString)
        {
            int power = 0;
            int decimalValue = 0;

            for (int i = 0; i < k_NumberLength; i++)
            {
                power = k_NumberLength - i - 1;
                if (i_BinaryNumberString[i] != '0')
                {
                    decimalValue += (int)Math.Pow(2, power);
                }
            }
            return decimalValue;
        }
        private void swapStringsInArray(int i_FirstString, int i_SecondString)
        {
            string temporaryBinaryNumber;
            temporaryBinaryNumber = m_BinaryNumbersGroup[i_FirstString];
            m_BinaryNumbersGroup[i_FirstString] = m_BinaryNumbersGroup[i_SecondString];
            m_BinaryNumbersGroup[i_SecondString] = temporaryBinaryNumber;
        }

        private void sortInDescendingOrderBinaryNumbersGroup()
        {
            for (int i = 0; i < k_GroupSize; i++)
            {
                for (int j = 0; j < k_GroupSize - i - 1; j++)
                {
                    if (getDecimalValue(m_BinaryNumbersGroup[j]) < getDecimalValue(m_BinaryNumbersGroup[j + 1]))
                    {
                        swapStringsInArray(j, j + 1);
                    }
                }
            }
        }
        private void printNumbersInDescendingOrder()
        {
            sortInDescendingOrderBinaryNumbersGroup();

            Console.Write("The input numbers in their decimal value and in descending order: ");
            char seperator = ',';
            int lastNumberInGroup = k_GroupSize - 1;

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

        public void GetInputFromUser()
        {
            string inputRequest = String.Format("Hello, please enter {0} Binary Numbers.", k_GroupSize);
            Console.WriteLine(inputRequest);
            for (int i = 0; i < k_GroupSize; i++)
            {
                string binaryNumberString = Console.ReadLine();
                while (checkInputValidation(binaryNumberString) == false)
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
            return;
        }
       

    }
}
