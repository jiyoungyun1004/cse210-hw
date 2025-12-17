using System;

class Program
{
    static void Main(string[] args)
    {
        // first job instance
        Job job1 = new Job();
        job1._jobTitle = "Math Tutor";
        job1._company = "Carrot Global";
        job1._startYear = 2023;
        job1._endYear = 2023;

        // second job instance
        Job job2 = new Job();
        job2._jobTitle = "AI trainer";
        job2._company = "Handshake";
        job2._startYear = 2025;
        job2._endYear = 2026;

        
        Resume myResume = new Resume();
        myResume._name = "Sophia Yun";

        // Add jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        
        myResume.Display();
    }
}