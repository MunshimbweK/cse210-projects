using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Reflection App!");

        while (true)
        {
            // Display the menu
            DisplayMenu();

            // Prompt the user for choice
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            // Perform the selected activity
            switch (choice)
            {
                case "1":
                    PerformReflection();
                    break;
                case "2":
                    PerformBreathingExercise();
                    break;
                case "3":
                    PerformListingActivity();
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Reflection");
        Console.WriteLine("2. Breathing Exercise");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("Type 'exit' to quit the program");
    }

    static void PerformReflection()
    {
        // Your code for reflection activity
        Console.WriteLine("Performing Reflection...");
    }

    static void PerformBreathingExercise()
    {
        // Your code for breathing exercise activity
        Console.WriteLine("Performing Breathing Exercise...");
    }

    static void PerformListingActivity()
    {
        // Your code for listing activity
        Console.WriteLine("Performing Listing Activity...");
    }
}