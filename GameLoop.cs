using System;

namespace Part_2_for_grades_A_and_B
{
    public static class GameLoop
    {
        private const string TimeFormat = "HH:mm:ss tt";
        public static readonly Controller Adventure = new();
        public static double Reputation;
        public static int NextLevel = 10;

        public static void MainLoop()
        {
            ConsoleKeyInfo key;

            do
            {
                //  Main loop core.
                var now = DateTime.Now;
                Console.WriteLine();
                Console.WriteLine(now.ToString(TimeFormat));
                Console.WriteLine("P = Patrol, A = Attack, Q = Quit");
                Console.Write("Reputation [" + Reputation + "] Level [" + Adventure.GetLevel() + "] Action [P,A,Q]: ");

                key = Console.ReadKey();

                Console.WriteLine();

                ActionController.DoAction(key.Key);
            } while (key.Key != ConsoleKey.Q && Adventure.GetLevel() < 10);

            if (Adventure.GetLevel() >= 10)
            {
                Console.WriteLine();
                Console.WriteLine("You WIN! Final score [" + Reputation + "]");
            }

            Console.ReadKey();
        }
    }
}