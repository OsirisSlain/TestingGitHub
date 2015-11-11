namespace Question
{
	using System;
	using System.Collections.Generic;
	
	class Program
	{
		static void Main()
		{
			int[] sample = {11, 4, 3, 3, 6, 3, 7, 2, 9};
			int[] expected = {-1, 3, 2, 1, 2, 1, 2, 1, -1};
			
			Console.WriteLine("Input");
			WriteLine(sample);
			
			Console.WriteLine("Expected");
			WriteLine(expected);
			
			var stackResult = NextLargest_Stack(sample);
			VerboseVerify(expected, stackResult, "Stack");
			
			var loopResult = NextLargest_Loop(sample);
			VerboseVerify(expected, loopResult, "Loop");
		}
		
		static void WriteLine(int[] a)
		{
			Console.WriteLine(String.Join(", ", a));
		}
		
		static bool VerboseVerify(int[] expected, int[] actual, string testName)
		{
			var result = Verify(expected, actual);
			
			if(result)
				Console.WriteLine(testName + " results match expected.");
			else
			{
				Console.WriteLine(testName + " results don't match expected:");
				WriteLine(actual);
			}
				
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
		
		//stack based solution
		static int[] NextLargest_Stack(int[] original)
		{
			int[] result = new int[original.Length];
			var index = new Stack<int>();
		
			for(int i = 0; i < original.Length; i++)
			{
				while(index.Count > 0 && original[i] > original[index.Peek()])
				{
					var top = index.Pop();
					result[top] = i - top;
				}
				index.Push(i);
			}
			while(index.Count > 0)
			{
				result[index.Pop()] = -1;
			}
			return result;
		}
		
		//simple nested loop solution
		static int[] NextLargest_Loop(int[] original)
		{
			int[] result = new int[original.Length];
			for(int i = 0; i < original.Length; i++)
			{
				result[i] = -1;
				for(int j = 1; j < original.Length - i; j++)
				{
					if(original[i] < original[i+j])
					{
						result[i] = j;
						break;
					}
				}
			}
			return result;
		}
	}
}