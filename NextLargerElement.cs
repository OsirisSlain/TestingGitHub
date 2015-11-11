using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int[] input = {11, 4, 3, 3, 6, 3, 7, 2, 9};
		int[] expected = {-1, 3, 2, 1, 2, 1, 2, 1, -1};
		
		Console.WriteLine("Input");
		WriteLine(input);
		Console.WriteLine("Expected");
		WriteLine(expected);
		
		var stackResult = NextLarger_Stack(input);
		var loopResult = NextLarger_Loop(input);
		VerboseVerify(expected, stackResult, "Stack");
		VerboseVerify(expected, loopResult, "Loop");
	}

	//simple nested loop solution
	static int[] NextLarger_Loop(int[] aa)
	{
		int[] result = new int[aa.Length];

		for(int i = 0; i < aa.Length; i++)
		{
			result[i] = -1;
			for(int j = 1; j < aa.Length - i; j++)
			{
				if(aa[i] < aa[i+j])
				{
					result[i] = j;
					break;
				}
			}
		}

		return result;
	}

	//stack based solution
	static int[] NextLarger_Stack(int[] aa)
	{
		int[] result = new int[aa.Length];
		var index = new Stack<int>();

		for(int i = 0; i < aa.Length; i++)
		{
			result[i] = -1;
			while(index.Count > 0 && aa[i] > aa[index.Peek()])
			{
				var top = index.Pop();
				result[top] = i - top;
			}
			index.Push(i);
		}

		return result;
	}

	static void WriteLine(int[] a)
	{
		Console.WriteLine(String.Join(", ", a));
	}
	
	static bool VerboseVerify(int[] expected, int[] actual, string testName)
	{
		var result = Verify(expected, actual);
		
		if(result)
			Console.WriteLine(testName + " results match expected:");
		else
			Console.WriteLine(testName + " results don't match expected:");
		WriteLine(actual);
			
		return result;
	}
	
	static bool Verify(int[] expected, int[] actual)
	{
		for(int i = 0; i < expected.Length; i++)
		{
			if(expected[i] != actual[i])
				return false;
		}
		return true;
	}
}
