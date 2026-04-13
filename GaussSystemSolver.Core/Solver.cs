namespace GaussSystemSolver.Core;

using System;
using System.Collections.Generic;
using System.Linq;

public static class Solver
{
	public static double[] Solve(this double[][] matrix, double[] freeMembers)
	{
		var rows = matrix.Length;
		var columns = matrix[0].Length;
		var pivotRowForColumn = new int[columns];
		Array.Fill(pivotRowForColumn, -1);
		var seenRows = new bool[rows];

		foreach (var column in Enumerable.Range(0, columns))
		{
			if (matrix.TryFindPivotRow(
				    column, 
				    Enumerable.Range(0, rows)
					    .Where(r => !seenRows[r]),
				    out var row)
			    )
			{
				seenRows[row] = true;
				pivotRowForColumn[column] = row;
				matrix.TransformByColumn(column, row, freeMembers);
			}
		}
		if (matrix.IsNotSolvable(freeMembers))
			throw new NoSolutionException("Provided matrix has no valid solution");
				
		return matrix.GetResult(freeMembers, pivotRowForColumn);
	}
}

public static class MatrixExtensions
{
	public static bool TryFindPivotRow(this double[][] matrix, int column, IEnumerable<int> rows, out int pivotRow)
	{
		foreach (var row in rows)
			if (!matrix[row][column].IsZero())
			{
				pivotRow = row;
				return true;
			}
		pivotRow = -1;
		return false;
	}
	
	public static void TransformByColumn
		(this double[][] matrix, int column, int pivotRow, double[] freeMembers)
	{
		foreach (var row in Enumerable.Range(0, matrix.Length)
			         .Where(r => r != pivotRow))
		{
			var pivot = matrix[pivotRow][column];
			var coef = matrix[row][column] / pivot;
			for (int c = 0; c < matrix[0].Length; c++)
				matrix[row][c] -= coef * matrix[pivotRow][c];
			freeMembers[row] -= coef * freeMembers[pivotRow];
		}
	}
	
	public static bool IsNotSolvable(this double[][] matrix, double[] freeMembers)
	{
		return matrix
			.Select((r, rowIndex) => (r, rowIndex))
			.Any(r => r.r
				.IsZeroRow() 
				&& !freeMembers[r.rowIndex].IsZero());
	}

	public static bool IsZeroRow(this IEnumerable<double> row) =>
		row.SkipWhile(e => e.IsZero()).Any() == false;

	public static double[] GetResult(this double[][] matrix, double[] freeMembers, int[] pivotRows)
	{
		return Enumerable.Range(0, matrix[0].Length)
			.Select(col =>
			{
				int row = pivotRows[col];
				return row == -1 
					? 0
					: freeMembers[row] / matrix[row][col];
			})
			.ToArray();
	}
	
	public static bool IsZero(this double x, double eps = 1e-9)
		=> Math.Abs(x) < eps;
}