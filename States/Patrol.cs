using Part_2_for_grades_A_and_B.Interfaces;
using System;

namespace Part_2_for_grades_A_and_B.States
{
    //  Interface the Patrol state with the IState interface.
    public class Patrol : IState
    {
        private readonly Controller _context;

        public Patrol(Controller context)
        {
            _context = context;
        }

        //  Main logic behind the Patrol mechanic of the adventure.
        public int Exploration()
        {
            Console.WriteLine("You start a new patrol.");

            var ran = RandomGenerator.GetRandomNumber(5);
            switch (ran)
            {
                case 0:
                    Console.WriteLine("Pirates are approaching! Prepare for battle!");
                    _context.SetState(_context.GetBattlePhaseState());
                    break;

                case 1:
                    Console.WriteLine("You find the pirates stolen goods stash!");
                    return 2;

                default:
                    Console.WriteLine("You don't find anything interesting");
                    break;
            }

            return 0;
        }

        public int BattlePhase(int level)
        {
            Console.WriteLine("You find nobody to attack.");
            return 0;
        }
    }
}