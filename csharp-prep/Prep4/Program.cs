using System;
using System.Collections.Generic;

class Program
{
    static void Main()

    {
        List<int> numbers = new List<int>();
        int inputNumber;

        Console.WriteLine("Enter a series of numbers (0 to finish)");
        // Keep asking until they type 0
            while (true)
            {
                Console.Write("Enter number: ");
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                    break;

                numbers.Add(input);
            }

            // If somehow they just entered 0 right away (edge case)
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers were entered.");
                return;
            }

            // Core Requirement 1: Sum
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine($"The sum is: {sum}");

            // Core Requirement 2: Average
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Core Requirement 3: Largest number
            int max = numbers[0];  // start with first one
            foreach (int num in numbers)
            {
                if (num > max)
                    max = num;
            }
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenges 

            // Stretch 1: Smallest positive number
            int smallestPositive = int.MaxValue;
            bool hasPositive = false;

            foreach (int num in numbers)
            {
                if (num > 0 && num < smallestPositive)
                {
                    smallestPositive = num;
                    hasPositive = true;
                }
            }

            if (hasPositive)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch 2: Sort and display the list
            // Using LINQ to sort 
            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

            Console.WriteLine("The sorted list is:");
            foreach (int num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
    
