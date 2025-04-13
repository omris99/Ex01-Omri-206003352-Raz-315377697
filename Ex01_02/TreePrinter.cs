using System;
using System.Text;
namespace Ex01_02
{
    public class TreePrinter
    {
        private int m_CurrentNumber = 1;
        private const int k_NumOfSpacesBetweenLabelAndNumbers = 3;
        public void PrintTree(int i_Height)
        {
            int treePartHeight = i_Height - 2;
            int maxRowLength = 2 * (treePartHeight - 1) + 1;

            printLineRecursive(0, treePartHeight, maxRowLength);
            printTrunk((char)('A' + treePartHeight), maxRowLength);
            printTrunk((char)('A' + treePartHeight + 1), maxRowLength);
        }
        private void printLineRecursive(int i_RowIndex, int i_TotalRows, int i_MaxRowLength)
        {
            if (i_RowIndex >= i_TotalRows)
            {
                return;
            }
            int rowLength = 2 * i_RowIndex + 1;
            int numOfPaddingSpacesForNumbers = i_MaxRowLength - rowLength;
            char label = (char)('A' + i_RowIndex);
            string numbersRow = TreeRowFormatter.BuildRowString(rowLength, ref m_CurrentNumber);
            string formattedRow = string.Format("{0}{1}{2}\n", label, new string(' ', numOfPaddingSpacesForNumbers + k_NumOfSpacesBetweenLabelAndNumbers + 1), numbersRow);
            Console.WriteLine(formattedRow);
            printLineRecursive(i_RowIndex + 1, i_TotalRows, i_MaxRowLength);
        }
        private void printTrunk(char i_Label, int i_MaxRowLength)
        {
            int numOfPaddingSpacesForTrunk = i_MaxRowLength - 1;
            string trunk = string.Format("{0}{1}|{2}|\n", i_Label, new string(' ', numOfPaddingSpacesForTrunk + k_NumOfSpacesBetweenLabelAndNumbers), m_CurrentNumber);
            Console.WriteLine(trunk);
        }
    }
}
