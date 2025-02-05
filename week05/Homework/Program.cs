using System;
using Homework;

class Program
{
    static void Main(string[] args)
    {
        // Math Assignment
        MathAssignment mathAssignment1 = new MathAssignment("Liam Nell", "Algebra", "Algebra for dummies", "1 - 10");

        // Writing Assignment
        WritingAssignment writingAssignment1 =
            new WritingAssignment("Rogan Nell", "Creative Writing", "The Aegis of Tron");
        
        // Log Math Homework
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());
        
        // Log Writing Homework
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
        
        
        
    }
    
    
}