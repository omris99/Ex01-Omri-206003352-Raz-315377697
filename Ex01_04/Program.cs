using System;
public class Program
{
    private string m_InputNumber;
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
        m_InputNumber = Console.ReadLine();
        while(checkInputLengthValidation() == false)
        {
            Console.WriteLine("Error, Try Again.");
            m_InputNumber = Console.ReadLine();
        }
    }

    public void PrintData()
    {
        bool stringConsistLettersOnly, stringConsistDigitsOnly;

        checkAndPrintIfPalindrome();
        checkIfStringConsistOnlyDigitsOrOnlyLetters(out stringConsistDigitsOnly, out stringConsistLettersOnly);
        if(stringConsistLettersOnly == true)
        {
            checkAndPrintHowManyCapitalLettersInString();
            checkAndPrintIfTheStringCharactersAreInAscendingLexicographyOrder();
        }
        else if(stringConsistDigitsOnly == true)
        {
            checkAndPrintIfNumberDividesByThreeWithoutRemainder();
        }
    }

    private bool checkInputLengthValidation()
    {
        bool inputIsValid = m_InputNumber.Length == k_StringLength;

        return inputIsValid;
    }

    private void checkAndPrintIfPalindrome()
    {
        int firstCharacterIndexInString = 0;
        int lastCharacterIndexInString = k_StringLength - 1;
        bool isPalindrome;

        isPalindrome = checkIfPalindrome(firstCharacterIndexInString, lastCharacterIndexInString);
        Console.WriteLine("Is palindrome: {0}", isPalindrome);
    }

    private bool checkIfPalindrome(int i_LeftCharIndex, int i_RightCharIndex)
    {
        bool isPalindrome = true;
        char rightCharacter = m_InputNumber[i_RightCharIndex];
        char leftCharacter = m_InputNumber[i_LeftCharIndex];

        if(i_LeftCharIndex <= i_RightCharIndex)
        {
            if(Char.ToLower(rightCharacter) != Char.ToLower(leftCharacter))
            {
                isPalindrome = false;
            }
            if(isPalindrome == true)
            {
                isPalindrome = checkIfPalindrome(++i_LeftCharIndex, --i_RightCharIndex);
            }
        }

        return isPalindrome;
    }

    private void checkIfStringConsistOnlyDigitsOrOnlyLetters(out bool o_StringConsistDigitsOnly, out bool o_StringConsistLettersOnly)
    {
        o_StringConsistLettersOnly = true;
        o_StringConsistDigitsOnly = true;

        for(int i = 0; i < k_StringLength; i++)
        {
            if(o_StringConsistDigitsOnly == true)
            {
                o_StringConsistDigitsOnly = Char.IsDigit(m_InputNumber[i]);
            }

            if(o_StringConsistLettersOnly == true)
            {
                o_StringConsistLettersOnly = Char.IsLetter(m_InputNumber[i]);
            }

            if(o_StringConsistDigitsOnly == false && o_StringConsistLettersOnly == false)
            {
                return;
            }
        }
    }

    private void checkAndPrintHowManyCapitalLettersInString()
    {
        int counter = 0;

        for(int i = 0; i < k_StringLength; i++)
        {
            if(Char.IsUpper(m_InputNumber[i]) == true)
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

        for(int i = 0; i < (k_StringLength - 1); i++)
        {
            currentLetter = Char.ToLower(m_InputNumber[i]);
            nextLetter = Char.ToLower(m_InputNumber[i + 1]);
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
        long number = long.Parse(m_InputNumber);
        bool NumberDivideByThreeWithoutRemainder = (number % 3 == 0);

        Console.WriteLine("Number Divides by 3 without remainder: {0}", NumberDivideByThreeWithoutRemainder);
    }
}