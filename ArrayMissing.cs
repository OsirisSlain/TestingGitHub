using System;
using System.Text;
using System.Linq;

class Program
{
	static void Main()
	{
		var missingNums = new int[] {18,34,57,77,59,79,98,99};
		var stringRep = GetStringRepresentation(missingNums);
		Console.WriteLine(stringRep);
	}
	
	static string GetStringRepresentation(int[] missingNums)
	{
		var sortedNums = missingNums.OrderBy(x => x).ToList();
		var stringRep = new StringBuilder();
		
		stringRep.Append(getPairString(-1,sortedNums[0]));
		for (int ii = 1; ii < sortedNums.Count - 1; ii++)
		{
			stringRep.Append(getPairString(sortedNums[ii], sortedNums[ii+1]));
		}
		stringRep.Append(getPairString(sortedNums[sortedNums.Count - 1], 100));
		
		stringRep.Length--; //get rid of comma
		return stringRep.ToString();
	}
	
	static string getPairString(int a, int b)
	{
		if(b-a<2)
			return "";
		if(b-a==2)
			return (b-1) + ",";
		if(b-a==3)
			return (a+1) + "," + (b-1) + ",";
		return (a+1) + "-" + (b-1) + ",";
	}
}