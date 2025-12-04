using System;

class Program
{
    static void Main(string[] args)
    {
        // First job entry
        var job1 = new Job
        {
            _jobTitle = "Math Tutor",
            _company = "Varsity Tutors",
            _startYear = 2023,
            _endYear = 2023
        };

        // Second job entry
        var job2 = new Job
        {
            _jobTitle = "AI Trainer",
            _company = "Handshake",
            _startYear = 2025,
            _endYear = 2026
        };

        // Build resume
        var myResume = new Resume
        {
            _name = "Sophia Yun"
        };

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display final resume
        myResume.Display();
    }
}
