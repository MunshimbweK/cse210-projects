using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Timestamp { get; set; }

    public Entry(string prompt, string response, DateTime timestamp)
    {
        Prompt = prompt;
        Response = response;
        Timestamp = timestamp;
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new Entry(prompt, response, DateTime.Now));
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Timestamp}: {entry.Prompt} - {entry.Response}");
        }
    }

    public void LoadJournal(string filename)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(',');
                    string prompt = parts[0];
                    string response = parts[1];
                    DateTime timestamp = DateTime.Parse(parts[2]);
                    entries.Add(new Entry(prompt, response, timestamp));
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading journal: " + ex.Message);
        }
    }

    // Implement methods for saving journal...
}

class Program
{
    static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    WriteNewEntry(journal);
                    break;
                case "2":
                    // Display the journal
                    journal.DisplayJournal();
                    break;
                case "3":
                    // Load the journal from a file
                    Console.Write("Enter the filename to load: ");
                    string filename = Console.ReadLine();
                    journal.LoadJournal(filename);
                    break;
                case "4":
                    // Exit the program
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine("Random Prompt: " + randomPrompt);
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        journal.AddEntry(randomPrompt, response);
        Console.WriteLine("Entry added successfully.");
    }
}
