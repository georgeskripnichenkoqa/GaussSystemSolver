using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GaussSystemSolver.Core;

public static class EquationSystemProvider
{
    public static double[][] GetMatrix(this IEnumerable<EquationState> equations)
    {
        return equations
            .Select(e => e.Variables
                .Select(c => (double)c.Value!)
                .ToArray())
            .ToArray();
    }

    public static double[] GetFreeMembers(this IEnumerable<EquationState> equations)
    {
        return equations
            .Select(e => (double)e.FreeMember.Value!)
            .ToArray();
    }
}