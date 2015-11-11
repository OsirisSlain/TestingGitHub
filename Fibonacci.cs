using System;
using System.Collections.Generic;

class Program
{
	static Dictionary<int,int> solutions = new Dictionary<int,int>();
	
	static void Main(string[] args)
	{
		int limit;
		if(!ArgParse.TryIntVerbose(args, out limit))
			return;
		int result = 0;
		for (int ii = 1; result < limit; ii++)
		{
			Console.Write(result + " ");
			result = Fibonacci(ii);
		}
		Console.WriteLine();
	}
	
	static int Fibonacci(int x)
	{
		if(x == 0 || x == 1) return x;
		int value;
		if(!solutions.TryGetValue(x, out value))
			solutions[x] = value = Fibonacci(x - 1) + Fibonacci(x - 2);
		return value;
	}
}
