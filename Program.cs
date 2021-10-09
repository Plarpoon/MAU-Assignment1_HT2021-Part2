//  This project is made for .NET 6 which is the default version on Windows 11
//  Thus using the new program style linked below
//  https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

using System.Text;

namespace Part_2_for_grades_A_and_B;

public static class Assignment1 // Assignment 1 (HT2021) Part 2
//  The idea came after seeing part 1 of the assignment and since the
//  professor provided example was somewhat of an interactive
//  series of events presenting themselves only in text format
//  I thought about doing the same but instead of dividing it in three different events
//  Have a one contiguous adventure from beginning to end
//  Even tho this small project actually doesn't really have an end.
{
    private const string TimeFormat = "HH:mm:ss tt";
    private static readonly Controller Adventure = new();
    private static double _reputation;
    private static int _nextLevel = 10;

    private static void Main()
    {
        ConsoleKeyInfo key;

        //  console initialization including small introduction.
        Console.OutputEncoding = Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Title = "Space Cadet Adventure";
        Console.WriteLine(">>>> Space Cadet Adventure <<<<");
        Console.WriteLine(
            "\n\nYou are a space cadet and your objective\nis to attack pirates and reclaim their loot!");
        Console.WriteLine("\nStart a 'patrol' to find pirates and attack them!\n");

        do
        {
            //  Main loop core.
            var now = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine(now.ToString(TimeFormat));
            Console.WriteLine("P = Patrol, A = Attack, Q = Quit");
            Console.Write("Reputation [" + _reputation + "] Level [" + Adventure.GetLevel() + "] Action [P,A,Q]: ");


            key = Console.ReadKey();

            Console.WriteLine();

            DoAction(key.Key);
        } while (key.Key != ConsoleKey.Q && Adventure.GetLevel() < 10);

        if (Adventure.GetLevel() >= 10)
        {
            Console.WriteLine();
            Console.WriteLine("You WIN! Final score [" + _reputation + "]");
        }

        Console.ReadKey();
    }

    private static void DoAction(ConsoleKey key)
    {
        //  Keyboard input reader.
        switch (key)
        {
            case ConsoleKey.P:
                {
                    var points = Adventure.Explore();
                    if (points > 0)
                    {
                        Console.WriteLine("You gain " + points + " reputation!");
                        _reputation += points;
                    }

                    break;
                }
            case ConsoleKey.A:
                {
                    var rounds = Adventure.Battle();
                    if (rounds > 0)
                    {
                        var points = 10 - rounds;
                        if (points < 0) points = 0;

                        _reputation += points;

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

        if (_reputation < _nextLevel) return;
        Adventure.SetLevel(Adventure.GetLevel() + 1);
        _nextLevel = Adventure.GetLevel() * 10;

        Console.WriteLine("The adventure achieved you a level! Level " + Adventure.GetLevel());
    }
}