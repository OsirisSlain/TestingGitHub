using System;

class Program
{
	static void Main(string[] args)
	{
		int number;
		if(!ArgParse.TryIntVerbose(args, out number))
			return;
		for (int ii = 1; ii <= number; ii++)
		{
			if(IsFactor(number,ii))
				Console.Write(ii + " ");
		}
		Console.WriteLine();
	}
	
	static bool IsFactor(int number, int factor)
	{
		if(factor == 1 || factor == number)
			return true;
			
		for(int ii = 2; ii * factor <= number; ii++)
		{
			if(ii * factor == number)
				return true;
		}
		return false;
	}
}
