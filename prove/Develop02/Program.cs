using System;
using System.Collections.Generic;
using System.IO;

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
        IterateEntries(entry => Console.WriteLine($"{entry.Timestamp},{entry.Prompt},{entry.Response}"));
    }

    public void LoadJournalFromCSV(string filename)
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

    public void SaveJournalToCSV(string filename)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    sw.WriteLine($"{entry.Prompt},{entry.Response},{entry.Timestamp}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving journal: " + ex.Message);
        }
    }

    public void IterateEntries(Action<Entry> action)
    {
        foreach (var entry in entries)
        {
            action(entry);
        }
    }
}

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
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournalToCSV(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournalFromCSV(loadFilename);
                    break;
                case "5":
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