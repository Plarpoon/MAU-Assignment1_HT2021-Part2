using Part_2_for_grades_A_and_B.Interfaces;
using System;
using System.Threading;

namespace Part_2_for_grades_A_and_B.States
{
    //  Interface the Battle state with the IState interface.
    public class BattleS : IState
    {
        private readonly Controller _context;
        private int _rounds;

        public BattleS(Controller context)
        {
            _context = context;
        }

        //  Main logic behind the Battle mechanic of the adventure.
        public int BattlePhase(int level)
        {
            Console.Write("You shoot the space pirates.. ");

            _rounds++;

            Thread.Sleep(1000);

            var maxRandomization = 10 - level;
            if (maxRandomization < 1) maxRandomization = 1;

            var ran = RandomGenerator.GetRandomNumber(maxRandomization);
            if (ran == 0)
            {
                Console.WriteLine("they are dead!");
                _context.SetState(_context.GetExplorationState());

                var tempRound = _rounds;
                _rounds = 0;

                return tempRound;
            }

            Console.WriteLine("but your aim sucks.");

            if (_rounds < 9) return 0;
            Console.WriteLine("You emergency warp drive to safety.");
            _context.SetState(_context.GetExplorationState());

            _rounds = 0;

            return 0;
        }

        public int Exploration()
        {
            Console.WriteLine("You can't escape!");
            return 0;
        }
    }
}