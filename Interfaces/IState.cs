//  This project is made for .NET 6 which is the default version on Windows 11
//  Thus using the new program style linked below
//  https://docs.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates

namespace Part_2_for_grades_A_and_B.Interfaces;

public interface IState
{
    int Exploration();
    int BattlePhase(int level);
}