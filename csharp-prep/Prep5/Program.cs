using System;

class Program
{
    // Show welcome message - simple void function
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Get the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Get favorite number as int
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Use 'out' to return birth year without needing a return value
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    // Square the number and return result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Display final results with name, squared number, and age calculation
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int ageThisYear = currentYear - birthYear;

        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {ageThisYear} this year.");
    }

    static void Main(string[] args)
    {
        // Call each function in order
        DisplayWelcome();

        string userName = PromptUserName();
        int favNumber = PromptUserNumber();

        // Using out parameter for birth year
        PromptUserBirthYear(out int birthYear);

        int squared = SquareNumber(favNumber);

        // Show the final output
        DisplayResult(userName, squared, birthYear);
    }
}