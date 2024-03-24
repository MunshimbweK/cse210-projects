 using System;

// Base class for all assignments
class Assignment
{
    // Common properties
    protected string studentName;
    protected string assignmentType;

    // Constructor
    public Assignment(string studentName, string assignmentType)
    {
        this.studentName = studentName;
        this.assignmentType = assignmentType;
    }

    // Method to get summary of the assignment
    public virtual string GetSummary()
    {
        return $"Assignment Type: {assignmentType}, Student: {studentName}";
    }
}

// Derived class for math assignments
class MathAssignment : Assignment
{
    // Additional properties specific to math assignments
    private string fractionType;
    private string homeworkDueDate;

    // Constructor
    public MathAssignment(string studentName, string assignmentType, string fractionType, string homeworkDueDate) 
        : base(studentName, assignmentType)
    {
        this.fractionType = fractionType;
        this.homeworkDueDate = homeworkDueDate;
    }

    // Method to get homework list (specific to math assignments)
    public string GetHomeworkList()
    {
        return $"Homework due on {homeworkDueDate}. Fraction type: {fractionType}";
    }
}

// Derived class for writing assignments
class WritingAssignment : Assignment
{
    // Additional properties specific to writing assignments
    private string writingTopic;

    // Constructor
    public WritingAssignment(string studentName, string assignmentType, string writingTopic) 
        : base(studentName, assignmentType)
    {
        this.writingTopic = writingTopic;
    }

    // Method to get writing information (specific to writing assignments)
    public string GetWritingInformation()
    {
        return $"Topic: {writingTopic}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
