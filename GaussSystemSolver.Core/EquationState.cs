using System.Collections.ObjectModel;

namespace GaussSystemSolver.Core;

public class EquationState
{
    public List<InputState> Variables { get; }
    public InputState FreeMember { get; }

    public EquationState(int variableCount)
    {
        Variables = new List<InputState>();
        for (int i = 0; i < variableCount; i++)
            Variables.Add(new InputState());

        FreeMember = new InputState();
    }
}
