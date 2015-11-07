using System;

class Program {
	static void Main() {
		Console.WriteLine("Welcome to Factor!");
		Console.Write("Please enter a positive integer: ");
		var input = Console.ReadLine().Trim();
		int number;
		if(!int.TryParse(input, out number)) {
			Console.WriteLine("Could not parse input.");
			Console.WriteLine("Goodbye.");
			return;
		}
		if(number < 1){
			Console.WriteLine("...a POSITIVE integer!");
			Console.WriteLine("Goodbye.");
			return;
		}
		Console.WriteLine("Factors of " + number + ":");
		for (int ii = 1; ii <= number; ii++)
		{
			if(IsFactor(number,ii)) Console.Write(ii + " ");
		}
	}
	
	static bool IsFactor(int number, int factor) {
		if(factor == 1 || factor == number) return true;
		int halfNumber = number/2;
		for(int ii = 2; ii <= halfNumber; ii++)
		{
			if(ii * factor == number) return true;
		}
		return false;
	}
}