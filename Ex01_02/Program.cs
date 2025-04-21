using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        private static int m_CurrentNumber = 1;
        private const int k_NumOfSpacesBetweenLabelAndNumbers = 3;
        private const int k_MinHeight = 4;
        private const int k_MaxHeight = 15;

        public static void Main()
        {
            PrintTree(7);
        }

        public static void PrintTree(int i_Height)
        {
            int heightWithoutTrunk = i_Height - 2;
            int maxRowLength = 2 * (heightWithoutTrunk - 1) + 1;
            if (i_Height < k_MinHeight || i_Height > k_MaxHeight)
            {
                Console.WriteLine("Invalid height. Please enter a number between 4 and 15.");
                return;
            }

            m_CurrentNumber = 1;
            PrintLineRecursive(0, heightWithoutTrunk, maxRowLength);
            PrintTrunk((char)('A' + heightWithoutTrunk), maxRowLength);
            PrintTrunk((char)('A' + heightWithoutTrunk + 1), maxRowLength);
        }

        private static void PrintLineRecursive(int i_RowIndex, int i_TotalRows, int i_MaxRowLength)
        {
            if (i_RowIndex >= i_TotalRows)
            {
                return;
            }

            int rowLength = (2 * i_RowIndex) + 1;
            int numOfPaddingSpacesForNumbers = i_MaxRowLength - rowLength;
            char label = (char)('A' + i_RowIndex);
            string numbersRow = BuildRowString(rowLength, ref m_CurrentNumber);
            string formattedRow = string.Format("{0}{1}{2}\n", label, new string(' ', numOfPaddingSpacesForNumbers + k_NumOfSpacesBetweenLabelAndNumbers + 1), numbersRow);

            Console.WriteLine(formattedRow);
            PrintLineRecursive(i_RowIndex + 1, i_TotalRows, i_MaxRowLength);
        }

        private static void PrintTrunk(char i_Label, int i_MaxRowLength)
        {
            int numOfPaddingSpacesForTrunk = i_MaxRowLength - 1;
            string trunk = string.Format("{0}{1}|{2}|\n", i_Label, new string(' ', numOfPaddingSpacesForTrunk + k_NumOfSpacesBetweenLabelAndNumbers), m_CurrentNumber);
            
            Console.WriteLine(trunk);
        }

        private static string BuildRowString(int i_NumberOfDigitsInRow, ref int io_CurrentNumber)
        {
            StringBuilder rowBuilder = new StringBuilder();

            for (int i = 0; i < i_NumberOfDigitsInRow; i++)
            {
                rowBuilder.Append(io_CurrentNumber);
                if (i < i_NumberOfDigitsInRow - 1)
                {
                    rowBuilder.Append(' ');
                }

                io_CurrentNumber++;
                if (io_CurrentNumber > 9)
                {
                    io_CurrentNumber = 1;
                }
            }

            return rowBuilder.ToString();
        }
    }
}
 