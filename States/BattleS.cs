//  This project is made for .NET 6 which is the default version on Windows 11
//  Thus using the new program style linked below
//  https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

using Part_2_for_grades_A_and_B.Interfaces;

namespace Part_2_for_grades_A_and_B.States;

public class BattleS : IState
{
    private readonly Controller _context;
    private int _rounds;

    public BattleS(Controller context)
    {
        _context = context;
    }

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