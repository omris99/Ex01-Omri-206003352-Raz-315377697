using System;

namespace Ex01_01
{
    public class BinaryNumber
    {
        private string m_BinaryNumberString;
        private int m_QuantityOfBits;
        public int ConvertToDecimal()
        {
            int decimalRepresentationOfBinaryNumber = 0;
            for (int i = 0; i < m_QuantityOfBits; i++)
            {
                if (m_BinaryNumberString[i] != 0)
                {
                    decimalRepresentationOfBinaryNumber += (int)Math.Pow(2,i);
                }
            }
            return decimalRepresentationOfBinaryNumber;
        }
        public static BinaryNumber Parse(string i_BinaryNumberString)
        {
            BinaryNumber newBinaryNumber = new BinaryNumber();
            newBinaryNumber.m_BinaryNumberString = i_BinaryNumberString;
            newBinaryNumber.m_QuantityOfBits = i_BinaryNumberString.Length;

            return newBinaryNumber;
        }

        public int GetLegnthOfLongestOnesSequence()
        {
            int totalLegnthOfLongestOnesSequence = 0;
            int currentLegnthOfLongestOnesSequence = 0;
            int previousDigit = -1;
            int currentDigit;
            for(currentDigit = 0; currentDigit < m_QuantityOfBits; currentDigit++)
            {
                if(m_BinaryNumberString[currentDigit] == '1')
                {
                    currentDigit = 1;
                    currentLegnthOfLongestOnesSequence++;
                }
                else
                {
                    currentDigit = 0;
                    if(previousDigit == 1 && currentDigit == 0)
                    {
                        if(currentLegnthOfLongestOnesSequence > totalLegnthOfLongestOnesSequence)
                        {
                            totalLegnthOfLongestOnesSequence = currentLegnthOfLongestOnesSequence;
                        }
                        currentLegnthOfLongestOnesSequence = 0;
                    }

                    currentLegnthOfLongestOnesSequence = 0;
                }
                previousDigit = currentDigit;
                currentDigit++;
            }
            return totalLegnthOfLongestOnesSequence;
        }

        public int StringToInt(string i_BinaryNumberString)
        {
            int intBinaryNumber = 0;
            int mostSignificantBitIndex = m_QuantityOfBits - 1;

            for (int i = 0; i < m_QuantityOfBits; i++)
            {
                if (i_BinaryNumberString[i] == '1')
                {
                    intBinaryNumber += (int)Math.Pow(10, mostSignificantBitIndex);
                }
                mostSignificantBitIndex--;
            }

            return intBinaryNumber;

        }
    }
}
