using System;
using YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        // Create Videos
        Video video1 = new Video("Learn how to user React JS in one hour!", "Super Cool Developer", 3600);
        Video video2 = new Video("Learn the basics of setting up a Wordpress Site", "Wordpress for Dummies", 1500);
        Video video3 = new Video("Why you should learn Python", "Python Master", 600);

        // Comments for first video
        video1.AddComment(new Comment("Phyllis_Loves_to_code", "This video was amazing! Super fun to watch!"));
        video1.AddComment(new Comment("Grumpy_Stanley", "Meh, I don't think I'll recommend this one."));
        video1.AddComment(new Comment("Everybody_loves_michael", "Now I can make a website to show off my work!"));
        
        // Comments for second video
        video2.AddComment(new Comment("Jimthejokester", "I should make a career switch"));
        video2.AddComment(new Comment("Pamela", "Make a tutorial on Wordpress themes"));
        video2.AddComment(new Comment("DwigthIsKing", "How do I beat AI"));
        video2.AddComment(new Comment("toby", "this is a really neat video"));
        
        // Comments for third video
        video3.AddComment(new Comment("Ryan_the_man", "I love Python!"));
        video3.AddComment(new Comment("KellyFahsonista", "Can you make a tldr version"));
        video3.AddComment(new Comment("mynameiscreed", "I don't know how to code"));
        
        Console.WriteLine(video1.DisplayVideoInformation());
        Console.WriteLine();
        Console.WriteLine(video2.DisplayVideoInformation());
        Console.WriteLine();
        Console.WriteLine(video3.DisplayVideoInformation());


    }
}