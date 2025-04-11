using System;

namespace Ex01_01
{
    public class BinaryNumbersGroup
    {
        private BinaryNumber[] m_BinaryNumbersGroup = new BinaryNumber[k_GroupSize];
        private const int k_GroupSize = 4;
        private const int k_NumberLength = 7;

        private bool checkInputValidation(string input)
        {
            bool validation = true;
            if(input.Length != k_NumberLength)
            {
                validation = false;
            }
            else if()
        }
        public void GetInputFromUser()
        {
            string inputRequest = String.Format("Hello, please enter {0} Binary Numbers.", k_GroupSize);
            Console.WriteLine(inputRequest);
            for(int i = 0; i < k_GroupSize; i++)
            {
                string binaryNumberString = Console.ReadLine();
                while(checkInputValidation() == false)
                {
                    Console.WriteLine("Error! Try again.");
                    binConsole.ReadLine();
                }
                m_BinaryNumbersGroup[i] = BinaryNumber.Parse(binaryNumberString);
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
                string toPrint = String.Format("{0}{1} ", m_BinaryNumbersGroup[i].DecimalValue(), seperator);
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
                sumOfAllNumbersInDecimal += m_BinaryNumbersGroup[i].DecimalValue();
            }
            decimalAverageOfAllBinaryNumbers = sumOfAllNumbersInDecimal / k_GroupSize;

            Console.WriteLine("Average: {0}", decimalAverageOfAllBinaryNumbers.ToString());
        }
        private void printStatistics()
        {
            calculateAndPrintDecimalAverage();
            findAndPrintTheLongestOnesSequenceLegnth();
            findAndPrintNumberOfExchangesBetweenZeroAndOneForEachNumber();
            findAndPrintNumberWithMostOnesCount();
            countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers();
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
                numberOfExchanges = m_BinaryNumbersGroup[i].GetQuantityOfExchangesBetweenZeroesAndOnes();
                Console.Write("({0}) {1}{2} ", m_BinaryNumbersGroup[i].ToString(), numberOfExchanges, seperator);
            }
        }
        private void findAndPrintNumberWithMostOnesCount()
        {
            int maxOnesCounted = 0;
            int currentOnesCount = 0;
            BinaryNumber numberWithTheMostOnesCount = BinaryNumber.Parse("0");
            for(int i = 0; i < k_GroupSize; i++)
            {
                currentOnesCount = m_BinaryNumbersGroup[i].GetQuantityOfOnesInNumber();
                if(currentOnesCount > maxOnesCounted)
                {
                    maxOnesCounted = currentOnesCount;
                    numberWithTheMostOnesCount = m_BinaryNumbersGroup[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Number with the most ones: {0}, (Binary: {1})", numberWithTheMostOnesCount.DecimalValue(), numberWithTheMostOnesCount.ToString());
        }

        private void countAndPrintTheTotalNumberOfOnesAppearsInGroupNumbers()
        {
            int onesCounter = 0;

            for(int i = 0; i < k_GroupSize; i++)
            {
                onesCounter += m_BinaryNumbersGroup[i].GetQuantityOfOnesInNumber();
            }
            Console.WriteLine("Total number Of ones counted: {0}", onesCounter);
        }
        private void findAndPrintTheLongestOnesSequenceLegnth()
        {
            int currentOnesSequenceLength;
            int longestOnesSequenceLength = 0;
            string numberWithTheLongestSequenceLength = "";
            for(int i = 0; i < k_GroupSize; i++)
            {
                currentOnesSequenceLength = m_BinaryNumbersGroup[i].GetLegnthOfLongestOnesSequence();
                if(currentOnesSequenceLength > longestOnesSequenceLength)
                {
                    longestOnesSequenceLength = currentOnesSequenceLength;
                    numberWithTheLongestSequenceLength = m_BinaryNumbersGroup[i].ToString();
                }
            }
            Console.WriteLine("Longest ones sequence length: {0} (in number {1})", longestOnesSequenceLength, numberWithTheLongestSequenceLength);
        }
        private void sortInDescendingOrderBinaryNumbersGroup()
        {
            for(int i = 0; i < k_GroupSize;i++)
            {
                for(int j = 0; j < k_GroupSize - i - 1; j++)
                {
                    if (m_BinaryNumbersGroup[j].DecimalValue() < m_BinaryNumbersGroup[j + 1].DecimalValue())
                    {
                        swapBinaryNumbers(j, j + 1);
                    }
                }
            }
        }
        private void swapBinaryNumbers(int i_FirstNumber, int i_SecondNumber)
        {
            BinaryNumber temporaryBinaryNumber;
            temporaryBinaryNumber = m_BinaryNumbersGroup[i_FirstNumber];
            m_BinaryNumbersGroup[i_FirstNumber] = m_BinaryNumbersGroup[i_SecondNumber];
            m_BinaryNumbersGroup[i_SecondNumber] = temporaryBinaryNumber;
        }
        public void PrintNumbersInDescendingOrderAndStatistics()
        {
            printNumbersInDescendingOrder();
            printStatistics();
            return;
        }


    }
}
