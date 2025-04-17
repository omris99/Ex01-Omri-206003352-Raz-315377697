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
        public static void Main()
        {
            //BinaryNumbersGroup binaryNumbersInput = new BinaryNumbersGroup();
            Program program = new Program();

            program.GetInputFromUser();
            program.PrintNumbersInDescendingOrderAndStatistics();
            //binaryNumbersInput.PrintNumbersInDescendingOrderAndStatistics();
        }

        public void PrintNumbersInDescendingOrderAndStatistics()
        {
            printNumbersInDescendingOrder();
            //printStatistics();
            return;
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
       

    }
}
