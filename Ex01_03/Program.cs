using System;
using Ex01_02;

public class Program
{
    private const int k_MinTreeHeight = 4;
    private const int k_MaxTreeHeight = 15;

    public static void Main()
    {
        int selectedTreeHeight = -1;
        bool isValidInput = false;

        Console.WriteLine("Enter tree height ({0}-{1}): ", k_MinTreeHeight, k_MaxTreeHeight);
        string userInput = Console.ReadLine();

        while(isValidInput == false)
        {
            if(int.TryParse(userInput, out selectedTreeHeight) == false)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            else if(selectedTreeHeight < k_MinTreeHeight || selectedTreeHeight > k_MaxTreeHeight)
            {
                Console.WriteLine("Invalid input. Please enter a number between 4 and 15.");
            }
            else
            {
                isValidInput = true;
                break;
            }

            userInput = Console.ReadLine();
        }

        Ex01_02.Program.PrintTree(selectedTreeHeight);
    }
}
