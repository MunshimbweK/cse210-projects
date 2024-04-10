using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            // Display menu options
            Console.WriteLine("===== Goal Tracker Menu =====");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("=============================");

            // Prompt user for choice
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateNewGoal();
                    break;
                case "2":
                    goalManager.ListGoals();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add a new line for readability
        }
    }
}

abstract class Goal
{
    protected string description;
    protected int points;

    protected Goal(string description, int points)
    {
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent();

    public virtual string Serialize()
    {
        return $"{description},{points}";
    }

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split(',');
        if (parts.Length == 2 && int.TryParse(parts[1], out int points))
        {
            return new SimpleGoal(parts[0], points);
        }
        else
        {
            return null; // Invalid data format
        }
    }

    public override string ToString()
    {
        return $"{description} ({points} points)";
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine("Recording event for simple goal.");
        return points;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine("Recording event for eternal goal.");
        return points;
    }
}

class ChecklistGoal : Goal
{
    private int completedTimes;
    private int totalTimes;

    public ChecklistGoal(string description, int points, int totalTimes) : base(description, points)
    {
        this.completedTimes = 0;
        this.totalTimes = totalTimes;
    }

    public override int RecordEvent()
    {
        Console.WriteLine("Recording event for checklist goal.");
        completedTimes++;
        if (completedTimes >= totalTimes)
        {
            Console.WriteLine("Congratulations! Checklist goal completed.");
            return points;
        }
        else
        {
            return 0;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} (Completed {completedTimes}/{totalTimes} times)";
    }
}

class GoalManager
{
    private List<Goal> goals;
    private const string saveFilePath = "goals.txt";

    public GoalManager()
    {
        goals = new List<Goal>();
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points associated with the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(description, points));
                break;
            case "3":
                Console.Write("Enter the total number of times the goal needs to be completed: ");
                int totalTimes = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(description, points, totalTimes));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals added yet.");
        }
        else
        {
            Console.WriteLine("===== All Goals =====");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"Goal {i + 1}: {goals[i]}");
            }
            Console.WriteLine("======================");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(saveFilePath))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        if (File.Exists(saveFilePath))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader(saveFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Goal goal = Goal.Deserialize(line);
                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter the index of the goal you want to record an event for:");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            int pointsEarned = goal.RecordEvent();
            Console.WriteLine($"Event recorded successfully! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}