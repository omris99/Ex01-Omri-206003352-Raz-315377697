using System;
using Ex01_02;

namespace Ex01_03
{
    public class Program
    {
        private const int k_MinTreeHeight = 4;
        private const int k_MaxTreeHeight = 15;

        public static void Main()
        {
            Console.Write($"Enter tree height ({k_MinTreeHeight}-{k_MaxTreeHeight}): ");
            string userInput = Console.ReadLine();

            bool isValidInput = int.TryParse(userInput, out int i_TreeHeight);

            if (isValidInput == false || i_TreeHeight < k_MinTreeHeight || i_TreeHeight > k_MaxTreeHeight)
            {
                Console.WriteLine("Invalid input. Please enter a number between 4 and 15.");
                return;
            }

            Ex01_02.Program.PrintTree(i_TreeHeight);
        }
    }
}
