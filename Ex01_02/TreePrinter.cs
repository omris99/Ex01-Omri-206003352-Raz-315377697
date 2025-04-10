using System;
namespace Ex01_02
{
    public class TreePrinter
    {
        private int m_Currentnumber = 1;
        private static readonly int[] sr_LineLengths = { 1, 3, 5, 7, 9 };
        private const int k_ManLineLength = 9;

        public void PrintTree() 
        {
            PrintLineRecursive(0);
            PrintTrunk('F');
            PrintTrunk('G');
        }
        private void PrintLineRecursive(int i_Index)
        {
            if (i_Index >= sr_LineLengths.Length)
            {
                return;
            }

            int lineLength = sr_LineLengths[i_Index];
            int paddingSpaces = (k_ManLineLength - lineLength);
            char label = (char)('A' + i_Index);

            string numbersRow = TreeRowFormatter.BuildRowString(lineLength, ref m_Currentnumber);
            string formattedRow = string.Format("{0}{1}{2}\n", label, new string(' ', paddingSpaces + 1), numbersRow);

            Console.WriteLine(formattedRow);

            PrintLineRecursive(i_Index + 1);
        }
        private void PrintTrunk(char i_Label) 
        {
            int paddingSpaces = (k_ManLineLength - 2);
            string trunkRow = string.Format("{0}{1}|8|\n", i_Label, new string(' ', paddingSpaces + 1));
            
            Console.WriteLine(trunkRow);
        }
    }
}
