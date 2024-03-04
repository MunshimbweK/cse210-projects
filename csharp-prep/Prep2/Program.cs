using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int score = int.Parse(answer);

        string letter = GetLetter(score);
        
        Console.WriteLine($"Your grade is: {letter}");

        if (score >= 70)
        {
            Console.WriteLine("Congratulations, well done!!!");
        }
        else
        {
            Console.WriteLine("To pass this class, you need C- but never give up, try again!!");
        }
    }

    static string GetLetter(int score)
    {
        string letter = "";

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (score % 10 >= 7)
        {
            letter += "+";
        }
        else if (score % 10 < 3 && score != 100)
        {
            letter += "-";
        }

        return letter;
    }
}
   