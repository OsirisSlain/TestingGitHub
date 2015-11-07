using System;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		var inputString = args[0];
		Console.WriteLine(CompressString(inputString));
	}
	
	static string CompressString(string original)
	{
		var currentItemCount = 1;
		char? currentItem = null;
		var compressed = new StringBuilder();
		
		foreach (var item in original)
		{
			if (currentItem == item)
				currentItemCount++;
			else
			{
				compressed.Append(currentItem);
				if(currentItemCount != 1)
					compressed.Append(currentItemCount);
				currentItemCount = 1;
				currentItem = item;
			}
		}
		compressed.Append(currentItem);
		return compressed.ToString();
	}
}