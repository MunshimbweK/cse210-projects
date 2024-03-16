using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();


        string userName = "";

        bool continuePlaying = true;  // the boolean value helps the user to opt out at any time during execution
        while (continuePlaying)       // The menu bar in in a while loop, makes the application organized, smart and neat                             //presents the user with a choice of what to execute
        {  
            DisplayMenu();   
            
                                    
            string userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "1":
                    userName = PromptUserName();
                    break;
                case "2":
                    int userNumber = PromptUserNumber();
                    int squaredNumber = SquareNumber(userNumber);
                    DisplayResult(userName, squaredNumber);
                    break;
                case "exit":
                    continuePlaying = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Enter your names");
        Console.WriteLine("2. Enter your favourite number and get its square");
        Console.WriteLine("Type 'exit' to quit the program");
        Console.WriteLine("Enter your choice: ");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
