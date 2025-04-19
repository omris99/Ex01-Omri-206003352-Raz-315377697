using System;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            NumberStatistics numbers = new NumberStatistics();
            numbers.GetInputFromUser();
            numbers.PrintStatistics();
        }
    }
}
