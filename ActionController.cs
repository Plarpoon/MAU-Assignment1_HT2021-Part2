using System;

namespace Part_2_for_grades_A_and_B
{
    public static class ActionController
    {
        public static void DoAction(ConsoleKey key)
        {
            //  Keyboard input reader.
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (key)
            {
                case ConsoleKey.P:
                    {
                        var points = GameLoop.Adventure.Explore();
                        if (points > 0)
                        {
                            Console.WriteLine("You gain " + points + " reputation!");
                            GameLoop.Reputation += points;
                        }

                        break;
                    }
                case ConsoleKey.A:
                    {
                        var rounds = GameLoop.Adventure.Battle();
                        if (rounds > 0)
                        {
                            var points = 10 - rounds;
                            if (points < 0) points = 0;

                            GameLoop.Reputation += points;

                            Console.WriteLine("You gain " + points + " rep points!");
                        }

                        break;
                    }
                case ConsoleKey.Q:
                    {
                        Environment.Exit(1);

                        break;
                    }
                default:
                    Console.WriteLine("You can play only with the buttons 'P', 'A' and 'Q'!");
                    break;
            }

            if (GameLoop.Reputation < GameLoop.NextLevel) return;
            GameLoop.Adventure.SetLevel(GameLoop.Adventure.GetLevel() + 1);
            GameLoop.NextLevel = GameLoop.Adventure.GetLevel() * 10;

            Console.WriteLine("The adventure achieved you a level! Level " + GameLoop.Adventure.GetLevel());
        }
    }
}