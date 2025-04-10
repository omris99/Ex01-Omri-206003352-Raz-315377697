using System;

namespace Ex01_01
{
    public class BinaryNumber
    {
        private string m_BinaryNumberString;
        private int m_QuantityOfBits;
        private int m_DecimalValue;

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
        
        private void assignDecimalValue()
        {
            int power = 0;

            for (int i = 0; i < m_QuantityOfBits; i++)
            {
                power = m_QuantityOfBits - i - 1;
                if (m_BinaryNumberString[i] != '0')
                {
                    m_DecimalValue += (int)Math.Pow(2, power);
                }
            }
        }
        public static BinaryNumber Parse(string i_BinaryNumberString)
        {
            BinaryNumber newBinaryNumber = new BinaryNumber();
            newBinaryNumber.m_BinaryNumberString = i_BinaryNumberString;
            newBinaryNumber.m_QuantityOfBits = i_BinaryNumberString.Length;
            newBinaryNumber.assignDecimalValue();

            return newBinaryNumber;
        }

        public int GetLegnthOfLongestOnesSequence()
        {
            int totalLegnthOfLongestOnesSequence = 0;
            int currentLegnthOfLongestOnesSequence = 0;
            int previousDigit = -1;
            int currentDigit;
            int leastSignificantBit = m_QuantityOfBits - 1;

            for(int i = 0; i < m_QuantityOfBits; i++)
            {
                if(m_BinaryNumberString[i] == '1')
                {
                    currentDigit = 1;
                    currentLegnthOfLongestOnesSequence++;
                    if(previousDigit == 1 && i == leastSignificantBit)
                    {
                        checkAndUpdateLegnthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                        currentLegnthOfLongestOnesSequence = 0;
                    }
                }
                else
                {
                    currentDigit = 0;
                    if(previousDigit == 1)
                    {
                        checkAndUpdateLegnthOfLongestOnesSequence(currentLegnthOfLongestOnesSequence, ref totalLegnthOfLongestOnesSequence);
                    }

                    currentLegnthOfLongestOnesSequence = 0;
                }
                previousDigit = currentDigit;
            }
            return totalLegnthOfLongestOnesSequence;
        }
        public int GetQuantityOfOnesInNumber()
        {
            int quantityOfOnes = 0;

            for(int i = 0; i < m_QuantityOfBits; i++)
            {
                if (m_BinaryNumberString[i] == '1')
                {
                    quantityOfOnes++;
                }
            }

            return quantityOfOnes;
        }

        public int GetQuantityOfExchangesBetweenZeroesAndOnes()
        {
            int quantityOfExchangesBetweenZeroesAndOnes = 0;
            int currentDigit; //change digit to bit
            int prevDigit = -1;
            for(int i = 0; i < m_QuantityOfBits; i++)
            {
                if (m_BinaryNumberString[i] == '1')
                {
                    currentDigit = 1;
                    if(prevDigit == 0)
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
        public int DecimalValue()
        {
            return m_DecimalValue;
        }
        public string ToString()
        {
            return m_BinaryNumberString;
        }
    }
}
