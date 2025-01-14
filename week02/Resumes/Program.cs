using System;
using Resumes;
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2001;
        job1._endYear = 2004;

        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "UX Designer";
        job2._startYear = 2006;
        job2._endYear = 2009;

        Resume resume = new Resume();
        resume._name = "Liam Nell";
        
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        
        resume.DisplayDetails();
    }
}