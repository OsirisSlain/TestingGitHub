using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		var cache = new LruCache<int,int>(getNum, 5);
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(cache.GetItem(i));
		}
		for (int i = 9; i >= 0; i--)
		{
			Console.WriteLine(cache.GetItem(i));
		}
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(cache.GetItem(i));
		}
	}
	
	static int getNum(int num)
	{
		Console.WriteLine("cache miss");
		return num;
	}
}