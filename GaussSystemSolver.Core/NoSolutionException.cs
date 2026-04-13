using System.Linq;

namespace GaussSystemSolver.Core;

using System;
using System.Text;

public class NoSolutionException : Exception
{
    public NoSolutionException(string message) : base(message)
    { }

    public NoSolutionException(double[][] initialMatrix, double[] freeMembers, double[][] matrixAfterSolve)
        : base(GetMessage(initialMatrix, freeMembers, matrixAfterSolve))
    { }

    private static string GetMessage(double[][] sourceMatrix, double[] freeMembers, double[][] solvedMatrix)
    {
        var builder = new StringBuilder();
        builder.Append("Initial matrix:" + Environment.NewLine + sourceMatrix.FormatMatrix() + Environment.NewLine);
        builder.Append("Free members: [" + string.Join(", ", freeMembers) + "]" + Environment.NewLine);
        builder.Append("Matrix after Solve:" + Environment.NewLine + solvedMatrix.FormatMatrix());
        return builder.ToString();
    }
}

public static class Extentions
{
    public static string FormatMatrix(this double[][] matrix)
    {
        return string.Join(Environment.NewLine, matrix.Select(row => string.Join("\t", row)));
    }
}