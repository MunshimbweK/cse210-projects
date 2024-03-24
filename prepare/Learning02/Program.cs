using System;
using System.Collections.Generic;

// Define the Job class to represent a job experience
class Job
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    // Constructor
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        JobTitle = jobTitle;
        Company = company;
        StartYear = startYear;
        EndYear = endYear;
    }
}

// Define the Resume class to represent a person's resume with multiple job experiences
class Resume
{
    public string Name { get; set; }
    public List<Job> Jobs { get; } = new List<Job>();

    // Constructor
    public Resume(string name)
    {
        Name = name;
    }

    // Method to display the resume
    public void Display()
    {
        Console.WriteLine($"Resume of {Name}:");
        Console.WriteLine("-------------------------------");
        foreach (var job in Jobs)
        {
            Console.WriteLine($"Job Title: {job.JobTitle}");
            Console.WriteLine($"Company: {job.Company}");
            Console.WriteLine($"Duration: {job.StartYear} - {job.EndYear}");
            Console.WriteLine("-------------------------------");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Job
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);

        // Create an instance of Resume
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to the resume
        myResume.Jobs.Add(job1);
        myResume.Jobs.Add(job2);

        // Display the resume
        myResume.Display();
    }
}
