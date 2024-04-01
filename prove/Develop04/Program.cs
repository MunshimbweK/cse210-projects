using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the ReflectionApp
        ReflectionApp app = new ReflectionApp();

        // Run the app
        app.Run();
    }
}

abstract class Activity
{
    public abstract void Start();
    protected void DisplaySpinner(int duration)
    {
        Console.Write("Loading.");
        for (int i = 0; i < duration; i++)
        {
            Thread.Sleep(5000); // Simulate processing
            Console.Write(".");
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public override void Start()
    {
        Console.WriteLine("===This activity will help you relax by walking you through breathing\n in and out slowly.Clear your mind and focus on breathing.===\n\n\n");
        Console.WriteLine("Breathe in deeply...");
        Thread.Sleep(5000); // Simulate pause
        Console.WriteLine("Hold...");
        Thread.Sleep(5000); // Simulate pause
        Console.WriteLine("Breathe out slowly...");
        Thread.Sleep(5000); // Simulate pause
        Console.WriteLine("Well done!");
        DisplaySpinner(5); // Display spinner for 5 seconds
    }
}

class ReflectionActivity : Activity
{
    private Random random = new Random();
    private string[] reflectionPrompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        
    };

    private string[] relatedQuestions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    public override void Start()
    {
        Console.WriteLine("===This activity will help you reflect on time in your life when you have shown strength\n and resilience.\n This will help you recognize the power you have\n and how you can use it in other aspects of your life:\n\n===  b  ");
        Console.WriteLine(GetRandomPrompt());
        Thread.Sleep(3000); // Simulate pause
        Console.WriteLine("Now, let's explore this further:");
        Console.WriteLine(GetRandomRelatedQuestion());
        DisplaySpinner(5); // Display spinner for 5 seconds
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(reflectionPrompts.Length);
        return reflectionPrompts[index];
    }

    private string GetRandomRelatedQuestion()
    {
        int index = random.Next(relatedQuestions.Length);
        return relatedQuestions[index];
    }
}

class ListingActivity : Activity
{
    private Random random = new Random();
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };
    public override void Start()
    {
        Console.WriteLine("=== This activity will help you reflect on the good things in your life by having you list as many things\n as you can in a certain area ===:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("");
        Console.WriteLine("Please provide your response: ");
        string response = Console.ReadLine();
        Console.WriteLine("Thank you for your response!");
        DisplaySpinner(5);
    }
    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}
//For continued learning and showing creativity I have added meditation activity 
// The meditation activity appealed to me and I felt, it will go hand in hand with the
// other activities. All my subclasses have inheritated from the superclass "Activity" and 
//my 4 subclasses, "Breathing", " Reflection", "Listing", & "Meditation" all have attributes from the parent class
//"Activity".
class MeditationActivity : Activity
{
    private Random random = new Random();
    private string[] meditationPrompts = new string[]
    {
        "Close your eyes and focus on your breath. Take slow, deep breaths.",
        "Imagine a peaceful place in your mind. Visualize yourself there.",
        "Scan your body from head to toe, releasing any tension you find.",
        "Repeat a calming mantra silently to yourself with each breath.",
    };

    public override void Start()
    {
        Console.WriteLine("=== Welcome to the Meditation Activity ===\n");
        Console.WriteLine("Find a comfortable position and prepare to relax.\n");

        // Guide the user through a series of meditation prompts
        foreach (string prompt in meditationPrompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(10000); // Pause for 10 seconds between prompts
        }

        Console.WriteLine("\nGreat job! You've completed the meditation session.");
        DisplaySpinner(5); // Display spinner for 5 seconds
    }
}

class ReflectionApp
{
    private Activity currentActivity;

    public void Run()
    {
        while (true)
        {
            DisplayMainMenu();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    break;
                case "2":
                    currentActivity = new ReflectionActivity();
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    break;
                case "4":
                    currentActivity = new MeditationActivity();
                    break;
                case "5":
                    Console.WriteLine("Exiting the app...");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            // Start the selected activity
            currentActivity.Start();
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine("Welcome to the Reflection App!");
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflection Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Start Meditation Activity");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }
}