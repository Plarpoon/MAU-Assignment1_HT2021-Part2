//  This project is made for .NET 6 which is the default version on Windows 11
//  Thus using the new program style linked below
//  https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

using Part_2_for_grades_A_and_B.Interfaces;
using Part_2_for_grades_A_and_B.States;

namespace Part_2_for_grades_A_and_B;

public class Controller
{
    private readonly IState _battleState;
    private readonly IState _exploreState;
    private int _level = 1;
    private IState _state;

    public Controller()
    {
        _exploreState = new Patrol(this);
        _battleState = new BattleS(this);

        _state = _exploreState;
    }

    public int Explore()
    {
        return _state.Exploration();
    }

    public int Battle()
    {
        return _state.BattlePhase(_level);
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void SetLevel(int level)
    {
        _level = level;
    }

    public int GetLevel()
    {
        return _level;
    }

    public IState GetExplorationState()
    {
        return _exploreState;
    }

    public IState GetBattlePhaseState()
    {
        return _battleState;
    }
}