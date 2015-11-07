using System;

class Program
{
	static int limit = 1000;
	static void Main() {
		Console.Write("0 1 ");
		Fibonacci(0, 1);
	}
	
	static void Fibonacci(int previous, int current) {
		int next = previous + current;
		if (next <= limit)
		{
			Console.Write(next + " ");
			Fibonacci(current, next);
		}
	}
}