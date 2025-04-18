//TODO:
//1. check input legnth
using System;
using Utilities;

namespace Ex01_04
{
    public class Program
    {
        private string m_Input;
        private int k_StringLength = 12;
        public static void Main()
        {
            Program program = new Program();
            program.AskUserForInput();
            program.PrintData();
        }
        public void AskUserForInput()
        {
            Console.WriteLine("Hello, Please Enter a string with exactly {0} characters: ", k_StringLength);
            m_Input = Console.ReadLine();

            while (checkInputLengthValidation() == false)
            {
                Console.WriteLine("Error, Try Again.");
                m_Input = Console.ReadLine();
            }

        }
        private bool checkInputLengthValidation()
        {
            bool inputIsValid = true;
            if (m_Input.Length != k_StringLength)
            {
                inputIsValid = false;
            }
            return inputIsValid;
        }

        public void PrintData()
        {
            bool stringConsistLettersOnly, stringConsistDigitsOnly;
            checkAndPrintIfPalindrome();
            checkIfStringConsistOnlyDigitsOrOnlyLetters(out stringConsistDigitsOnly, out stringConsistLettersOnly);
            if (stringConsistLettersOnly == true)
            {
                checkAndPrintHowManyCapitalLettersInString();
                checkAndPrintIfTheStringCharactersAreInAscendingLexicographyOrder();
            }
            else if (stringConsistDigitsOnly == true)
            {
                checkAndPrintIfNumberDividesByThreeWithoutRemainder();
            }
        }
        private void checkAndPrintIfPalindrome()
        {
            int firstCharacterIndexInString = 0;
            int lastCharacterIndexInString = k_StringLength - 1;
            bool isPalindrome;

            isPalindrome = checkIfPalindrome(firstCharacterIndexInString, lastCharacterIndexInString);
            Console.WriteLine("Is palindrome: {0}", isPalindrome);
        }
        private bool checkIfPalindrome(int leftCharIndex, int rightCharIndex)
        {
            bool isPalindrome = true;
            char rightCharacter = m_Input[rightCharIndex];
            char leftCharacter = m_Input[leftCharIndex];
            if (leftCharIndex <= rightCharIndex)
            {
                if (Char.ToLower(rightCharacter) != Char.ToLower(leftCharacter))
                {
                    isPalindrome = false;
                }
                if (isPalindrome == true)
                {
                    isPalindrome = checkIfPalindrome(++leftCharIndex, --rightCharIndex);
                }
            }
            return isPalindrome;
        }
        private void checkIfStringConsistOnlyDigitsOrOnlyLetters(out bool o_StringConsistDigitsOnly, out bool o_StringConsistLettersOnly)
        {
            o_StringConsistLettersOnly = true;
            o_StringConsistDigitsOnly = true;

            for (int i = 0; i < k_StringLength; i++)
            {
                if (Char.IsDigit(m_Input[i]) == false)
                {
                    o_StringConsistDigitsOnly = false;
                }

                if (Char.IsLetter(m_Input[i]) == false)
                {
                    o_StringConsistLettersOnly = false;
                }

                if (o_StringConsistDigitsOnly == false && o_StringConsistLettersOnly == false)
                {
                    return;
                }
            }

        }

        private void checkAndPrintHowManyCapitalLettersInString()
        {
            int counter = 0;

            for (int i = 0; i < k_StringLength; i++)
            {
                if (Char.IsUpper(m_Input[i]) == true)
                {
                    counter++;
                }
            }
            Console.WriteLine("Quantity of capital letters: {0}", counter);
        }

        private void checkAndPrintIfTheStringCharactersAreInAscendingLexicographyOrder()
        {
            char currentLetter;
            char nextLetter;
            bool areStringCharactersInAscendingLexicographyOrder = true;

            for (int i = 0; i < (k_StringLength - 1); i++)
            {
                currentLetter = Char.ToLower(m_Input[i]);
                nextLetter = Char.ToLower(m_Input[i + 1]);
                if (currentLetter > nextLetter)
                {
                    areStringCharactersInAscendingLexicographyOrder = false;
                    break;
                }
            }
            Console.WriteLine("String characters are in ascending lexicography order: {0}", areStringCharactersInAscendingLexicographyOrder);
        }
        private void checkAndPrintIfNumberDividesByThreeWithoutRemainder()
        {
            NumbersFeatures.CheckIfNumberDividesByThreeWithoutRemainder(long.Parse(m_Input));
            bool isNumberDivideByThreeWithoutRemainder = NumbersFeatures.CheckIfNumberDividesByThreeWithoutRemainder(long.Parse(m_Input));

            Console.WriteLine("Number Divides by 3 without remainder: {0}", isNumberDivideByThreeWithoutRemainder);
        }
    }


}
