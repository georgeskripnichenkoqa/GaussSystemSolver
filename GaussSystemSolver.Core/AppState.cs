using System.Collections.ObjectModel;

namespace GaussSystemSolver.Core;

public partial class AppState
{
    public List<EquationState> Equations {get; set;}
    private int MatrixSize => Equations.Count;
    public double[]? Solution { get; private set; }
    public string? ErrorMessage { get; private set; }

    public AppState(int initialEquationCount)
    {
        Equations = new List<EquationState>();

        for(var i = 0; i < initialEquationCount; i++)
            AddEquation();
    }
    
    public static AppState CreateDefault()
        => new(initialEquationCount: 3);
    
    public void RemoveEquation(EquationState eq)
    {
        Equations.Remove(eq);

        foreach (var e in Equations)
        {
            e.Variables.RemoveAt(e.Variables.Count - 1);
        }
    }
    
    public void AddEquation()
    {
        int count = MatrixSize + 1;

        foreach (var eq in Equations)
        {
            eq.Variables.Add(new InputState());
        }

        Equations.Add(new EquationState(count));
    }
    
    public void Solve()
    {
        ErrorMessage = null;
        Solution = null;

        try
        {
            var matrix = Equations.GetMatrix();
            var freeMembers = Equations.GetFreeMembers();
            Solution = matrix.Solve(freeMembers);
        }
        catch (NoSolutionException ex)
        {
            ErrorMessage = ex.Message;
        }
    }
    
    public bool CanSolve =>
        Equations.Count > 0 &&
        Equations.All(e =>
            e.FreeMember.IsValid &&
            e.Variables.All(v => v.IsValid)
        );
    public void ClearResults()
    {
        Solution = null;
        ErrorMessage = null;
    }
    
    public void ClearInputsAndResults()
    {
        foreach (var e in Equations)
        {
            foreach (var v in e.Variables)
                v.Update("");
            e.FreeMember.Update("");
        }
        ClearResults();
    }
    
    /// <summary>
    /// Returns variable name based on it's current index in the equation.
    /// </summary>
    /// <param name="index">Current varuable index in the equation</param>
    /// <returns>Name in excel-based format. So it's a-z, then aa-az, then ba-bz etc.</returns>
    public static string GetVariableName(int index)
    {
        string name = "";
        do
        {
            name = (char)('a' + (index % 26)) + name;
            index = index / 26 - 1;
        }
        while (index >= 0);
        return name;
    }
}