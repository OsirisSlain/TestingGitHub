using System;

class Program
{
	static void Main()
	{
		var matrixA = new int[,] {{-1,4,3},{5,2,3},{5,2,3}};
		var matrixB = new int[,] {{1},{3},{5}};
		MatrixMultiply(matrixA, matrixB);
	}
	
	static int[,] MatrixMultiply(int[,] matrixA, int[,] matrixB)
	{
		var rowsA = matrixA.GetLength(0);
		var columnsA = matrixA.GetLength(1);
		var rowsB = matrixB.GetLength(0);
		var columnsB = matrixB.GetLength(1);
		
		if (columnsA != rowsB)
		{
			throw new Exception("Columns of A don't match rows of B");
		}
		
		var matrixR = new int[rowsA,columnsB];
		
		var temp = matrixA[0,0] * matrixB[0,0];
		temp += matrixA[0,1] * matrixB[1,0];
		
		for (int ii = 0; ii < rowsA; ii++)
		{
			for (int jj = 0; jj < columnsB; jj++)
			{
				matrixR[ii,jj] = SumProducts(matrixA, matrixB, ii, jj);
				Console.Write(matrixR[ii,jj] + "\t");
			}
			Console.WriteLine();
		}
		
		return matrixR;
	}
	
	static int SumProducts(int[,] a, int [,] b, int row, int column)
	{
		var sum = 0;
		var length = a.GetLength(1);
		for (int ii = 0; ii < length; ii++)
		{
			sum += a[row,ii] * b[ii,column];
		}
		return sum;
	}
}