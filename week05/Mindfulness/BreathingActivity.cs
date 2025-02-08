using Mindfulness;

namespace Mindfulness
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.") {}

        public void Run()
        {
            DisplayStartingMessage();

            for (int i = 0; i < GetDuration() / 6; i++)
            {
                Console.WriteLine("Breath in...");
                ShowCountDown(5);
                Console.WriteLine("Breath out...");
                ShowCountDown(5);

            }

            DisplayEndingMessage();
            
        }
    }
}

