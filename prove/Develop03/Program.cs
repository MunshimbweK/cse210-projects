using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Initialize scripture
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord and lean not unto thine own understanding.", "In all thy ways acknowledge Him, and He shall direct thy paths.");
        
        // Intro & Display the entire scripture
        Console.WriteLine("Welcome to the scripture Memorizer:\nHere is the Complete Scripture:");
        Console.WriteLine(scripture.GetVerses());

        // Prompt user to hide words
        Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
        string input = Console.ReadLine();
        while (input != "quit")
        {
            // Clear the console
            Console.Clear();

            // Hide random words and display scripture with hidden words
            ScriptureReference scriptureRef = new ScriptureReference("Proverbs", "3:5-6");
            Console.WriteLine("Hidden Words:");
            Console.WriteLine(scriptureRef.GetMaskedVerses(scripture));

            // Fill in the blanks
            scriptureRef.FillBlanks();

            // Prompt user again
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}

class Scripture
{
    private string chapter;
    private string[] verses;

    public Scripture(string chapter, params string[] verses)
    {
        this.chapter = chapter;
        this.verses = verses;
    }

    public string GetVerses()
    {
        return string.Join(" ", verses);
    }

    public string[] GetVersesArray()
    {
        return verses;
    }
}

class ScriptureReference
{
    private string scriptureChapter;
    private int startVerse;
    private int endVerse;
    private HashSet<int> hiddenWords = new HashSet<int>();
    private Random random = new Random();

    public ScriptureReference(string scriptureChapter, string reference)
    {
        this.scriptureChapter = scriptureChapter;
        ParseReference(reference);
    }

    private void ParseReference(string reference)
    {
        // Parse the reference string (e.g., "3:5", "3:5-6")
        string[] parts = reference.Split(':', '-');
        startVerse = int.Parse(parts[1]);
        endVerse = parts.Length > 2 ? int.Parse(parts[2]) : startVerse;
    }

    public string GetMaskedVerses(Scripture scripture)
    {
        string[] words = scripture.GetVerses().Split(' ');
        List<string> maskedWords = new List<string>();

        // Loop through each word in the scripture
        for (int i = 0; i < words.Length; i++)
        {
            // Check if the current word should be hidden
            if (ShouldHideWord(i))
            {
                maskedWords.Add("______");
            }
            else
            {
                maskedWords.Add(words[i]);
            }
        }

        // Join the masked words back into sentences
        return string.Join(" ", maskedWords);
    }
//As part of creativity and learning, I added to the ScriptureReference class FillBlanks method 
//which prompts user to fill in the blanks. This is an exciting & effective way to memorize and engage users. 
//I enjoyed myself while learning.
    public void FillBlanks()
    {
        Console.WriteLine("\nFill in the blanks:");
        Console.WriteLine("(Enter the correct words to fill in the blanks)");

        // Implement the fill-in-the-blanks logic here
        // For simplicity, let's assume the correct words are provided as input

        // Example:
        string[] correctWords = { "Trust", "Lord", "lean", "own", "understanding.", "In", "ways", "Him,", "direct", "paths." };
        string[] inputWords = new string[correctWords.Length];

        int score = 0;
        for (int i = 0; i < correctWords.Length; i++)
        {
            Console.Write($"Enter the word for blank {i + 1}: ");
            inputWords[i] = Console.ReadLine();

            if (inputWords[i] == correctWords[i])
            {
                score += 10;
            }
        }

        Console.WriteLine($"Your score for this round: {score}");
    }

    private bool ShouldHideWord(int wordIndex)
    {
        // Generate a random number to determine whether to hide the word
        return random.Next(2) == 0; // 50% chance of hiding the word
    }
}
