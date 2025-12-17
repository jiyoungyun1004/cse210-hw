using System;
using System.Collections.Generic;

public class Resume
{
    
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Constructor
    public Resume()
    {
    }

    // Display method
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Iterate through each job in the list and display it
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}