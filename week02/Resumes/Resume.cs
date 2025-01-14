using Resumes;

namespace Resumes;

public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");

        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}