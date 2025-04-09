using System.Text;

namespace Ex01_02
{
    public static class TreeRowFormatter
    {
        public static string BuildRowString(int i_NumCount, ref int io_CurrentNumber)
        {
            StringBuilder rowBuilder = new StringBuilder();

            for (int i = 0; i < i_NumCount; i++)
            {
                rowBuilder.Append(io_CurrentNumber);
                rowBuilder.Append(' ');

                io_CurrentNumber++;

                if (io_CurrentNumber > 9)
                {
                    io_CurrentNumber = 1;
                }
            }

            return rowBuilder.ToString().TrimEnd();
        }

    }
}