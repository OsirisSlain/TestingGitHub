using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int[] missing = {0,1,3,5,7,18,34,57,77,59,79,98,99};
		Console.WriteLine(ToRangeString(missing));
	}

	public static string ToRangeString(int[] missing)
	{
		var sorted = missing.OrderBy(x => x).ToList();
		var substrings = new List<string>();
		
		substrings.Add(getRange(-1,sorted[0]));
		for (int ii = 1; ii < sorted.Count - 1; ii++)
			substrings.Add(getRange(sorted[ii], sorted[ii+1]));
		substrings.Add(getRange(sorted[sorted.Count - 1], 100));

		return String.Join(",", substrings.Where(x => x != null));
	}
	
	private static string getRange(int a, int b)
	{
		if(b-a<2) return null;
		if(b-a==2) return (b-1).ToString();
		return (a+1) + ((b-a==3) ? "," : "-") + (b-1);
	}
}
