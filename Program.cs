using System;
using System.Text;

namespace Part_2_for_grades_A_and_B
{
    public static class Assignment1 //  Assignment 1 (HT2021) Part 2
                                    //  The idea came after seeing part 1 of the assignment and since the
                                    //  professor provided example was somewhat of an interactive
                                    //  series of events presenting themselves only in text format
                                    //  I thought about doing the same but instead of dividing it in three different events
                                    //  Have a one contiguous adventure from beginning to end
                                    //  Even tho this small project actually doesn't really have an end.
    {
        private static void Main()
        {
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

            GameLoop.MainLoop();
        }
    }
}