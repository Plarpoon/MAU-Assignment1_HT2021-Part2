using System;

namespace Part_2_for_grades_A_and_B
{
    //  The adventure is fully randomized, this is a the base of pretty much everything.
    public static class RandomGenerator
    {
        private static readonly Random Random = new();

        public static int GetRandomNumber(int maxValue)
        {
            return Random.Next(maxValue);
        }
    }
}