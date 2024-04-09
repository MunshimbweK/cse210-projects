using System;

// Abstract base class representing common attributes and behavior for social media entities
public abstract class Goal
{
    // Encapsulation: Private field to store the description
    private string description;

    // Abstraction: Constructor to initialize the description
    protected Goal(string description)
    {
        this.description = description;
    }

    // Abstraction: Abstract method to record events
    public abstract int RecordEvent();

    // Abstraction: Method to convert the goal to a string representation
    public override string ToString()
    {
        return description;
    }

    // Polymorphism: Static factory method to deserialize a goal based on data
    public static Goal Deserialize(string data)
    {
        // For simplicity, always deserialize as a SimpleGoal in this example
        return new SimpleGoal(data);
    }

    // Encapsulation: Method to set a deadline for the goal
    public void SetDeadline(DateTime deadline)
    {
        Console.WriteLine($"Deadline set for the goal: {deadline}");
    }

    // Encapsulation: Method to check if the goal is overdue
    public bool IsOverdue()
    {
        // For simplicity, always return false in this example
        return false;
    }
}

// Concrete subclass representing a simple goal
class SimpleGoal : Goal
{
    public SimpleGoal(string description) : base(description)
    {
    }

    // Override the RecordEvent method to provide specific implementation for SimpleGoal
    public override int RecordEvent()
    {
        Console.WriteLine("Recording event for simple goal.");
        return 100; // Example points earned for recording an event related to the simple goal
    }
}

// Concrete subclass representing an eternal goal
class EternalGoal : Goal
{
    public EternalGoal(string description) : base(description)
    {
    }

    // Override the RecordEvent method to provide specific implementation for EternalGoal
    public override int RecordEvent()
    {
        Console.WriteLine("Recording event for eternal goal.");
        return 100; // Example points earned for recording an event related to the eternal goal
    }
}

// Main program class
class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Creating instances of SimpleGoal and EternalGoal
        Goal simpleGoal = new SimpleGoal("Complete daily exercise routine");
        Goal eternalGoal = new EternalGoal("Read a book every week");

        // Setting deadlines for goals
        simpleGoal.SetDeadline(DateTime.Now.AddDays(7)); // Set deadline for 7 days from now
        eternalGoal.SetDeadline(DateTime.Now.AddDays(30)); // Set deadline for 30 days from now

        // Checking if goals are overdue
        Console.WriteLine($"Is simple goal overdue? {simpleGoal.IsOverdue()}");
        Console.WriteLine($"Is eternal goal overdue? {eternalGoal.IsOverdue()}");
    }
}