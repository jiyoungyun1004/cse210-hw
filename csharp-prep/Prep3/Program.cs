using System;
using System.Security.Authentication;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        Console.WriteLine("Welcome to the Guess My Number Game!");
        Console.WriteLine("-----------------------------");
        //Loop the entire game until the user says they don't want to play again
        while (playAgain.ToLower() == "yes")
        {

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
        int guessCount = 0;
            //Keep looping until the player guesses correctly
            
            
            if (guess==magicNumber)
            {
                Console.Write("What is your guess?");
                string input = Console.ReadLine();

                //Check for valid input 
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.\n");
                    continue;
                }
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher\n");

                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower\n");

                }
                else if (guess == magicNumber)
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} tries.\n");

                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }
        Console.WriteLine("Thanks for playing! Goodbye!");
        
    }
}