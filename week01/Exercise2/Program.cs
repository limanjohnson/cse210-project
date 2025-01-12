using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade? ");
        string myGrade = Console.ReadLine();
        int myGradeInt = int.Parse(myGrade);
        

        string letter = "";
        
        // Determine Letter Grade

        if (myGradeInt >= 90)
        { 
            letter = "A";
        }
        else if (myGradeInt >= 80)
        {
            letter = "B";
        }
        else if (myGradeInt >= 70)
        {
            letter = "C";
        }
        else if (myGradeInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        int lastDigit = myGradeInt % 10;

        if (myGradeInt >= 60 && myGradeInt < 97)
        {
            if (lastDigit >= 7)
            {
                letter += "+";
            }
            else if (lastDigit < 3)
            {
                letter += "-";
            }
        }
        

        string gradeSign(int grade)
        {
            return grade >= 60 ? "+" : "-";
        }
        
        Console.WriteLine($"You received a {letter}.");

        if (myGradeInt >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You failed the class.");
        }
        
        


    }
}