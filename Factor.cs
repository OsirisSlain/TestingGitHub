using System;

class Program
{
	static void Main(string[] args)
	{
		int number;
		if(!ArgParse.TryInt(args, out number))
			return;
		for (int ii = 1; ii <= number; ii++)
		{
			if(IsFactor(number,ii)) Console.Write(ii + " ");
		}
	}
	
	static bool IsFactor(int number, int factor)
	{
		if(factor == 1 || factor == number)
			return true;
			
		int halfNumber = number/2;
		for(int ii = 2; ii <= halfNumber; ii++)
		{
			if(ii * factor == number)
				return true;
		}
		return false;
	}
}