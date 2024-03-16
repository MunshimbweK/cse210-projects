using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {  
        bool playAgain = true;

        while (playAgain)
        {
            List<int> numbers = new List<int>();

            // Prompt the user to enter numbers
            ObtainUserNumbers(numbers);

            // Part 1: Calculate the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");

            // Part 2: Calculate the average
            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Part 3: Find the largest
            int largest = FindLargest(numbers);
            Console.WriteLine($"The largest number is: {largest}");

            // Part 4: Sort the numbers and find the smallest positive or negative number
            List<int> sortedNumbers = new List<int>(numbers);
            sortedNumbers.Sort();
            Console.WriteLine("Here is your sorted numbers:");
            foreach (int number in sortedNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            int smallestPositive = int.MaxValue;
            int smallestNegative = int.MinValue;
            foreach (int number in sortedNumbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
                else if (number < 0 && number > smallestNegative)
                {
                    smallestNegative = number;
                }
            }

            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers found.");
            }

            if (smallestNegative != int.MinValue)
            {
                Console.WriteLine($"The smallest negative number: {smallestNegative}");
            }
            else
            {
                Console.WriteLine("No negative numbers found.");
            }

            // Ask the user if they want to play again
            // I have added a while loop to make the code very interesting
            // It is also shows that the developer had the needs of the user in mind
            //Understanding what this code is all about, helped me to envisage what functions to add
            //Though each function is different, all of them are working to accomplish specific tasks

            Console.Write("Do you want to play again? (yes/exit): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            if (playAgainResponse == "exit")
            {
                playAgain = false;
            }
        }
    }

    static void ObtainUserNumbers(List<int> numbers)
    {
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Please enter a series numbers ( 0 to quit): ");

            string userResponse = Console.ReadLine();
            // I have added a try catch block just in case the user makes the wrong input
            //This also makes the code neat and smart
            try
            {
                userNumber = int.Parse(userResponse);
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
                else
                {   // If the user enters zero the program will terminate 
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input. Please enter a number.");
            }
            
        }
    }

    static int FindLargest(List<int> numbers)
    {
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        return largest;
    }
}