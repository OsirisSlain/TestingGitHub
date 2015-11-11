namespace Question
{
using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int[] sample = {11, 4, 3, 3, 6, 3, 7, 2, 9};
		var nextLargest = NextLargestFast(sample);
		foreach (var item in nextLargest)
		{
			Console.Write(item + " ");
		}
	}
	
	//stack based solution
	static int[] NextLargestFast(int[] original)
	{
		int[] result = new int[original.Length];
		var index = new Stack<int>();
		//Func<int> top = () => index.Peek();
	
		for(int i = 0; i < original.Length; i++)
		{
			while(index.Count > 0 && original[i] > original[index.Peek()])
			{
				result[index.Peek()] = i - index.Peek();
				index.Pop();
			}
			index.Push(i);
		}
		while(index.Count > 0)
		{
			result[index.Pop()] = -1;
		}
		return result;
	}
}
}