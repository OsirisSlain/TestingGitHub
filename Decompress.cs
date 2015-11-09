using System;
using System.Text;

class Program
{
	static void Main()
	{
		string compressed = "This5 i3s3 a Test.3";
		var decompressed = Decompress(compressed);
		Console.WriteLine(decompressed);
	}
	
	static string Decompress(string compressed)
	{
		var decompressed = new StringBuilder();
		var count = new StringBuilder();
		char? last = null;
		char? current = null;
		
		foreach(var c in compressed + "X")
		{
			if(Char.IsDigit(c))
			{
				count.Append(c);
			}
			else
			{
				int repeat;
				int.TryParse(count.ToString(), out repeat);
				count = new StringBuilder();
				if (repeat == 0)
					repeat = 1;
				for(int i = 0; i < repeat; i++)
				{
					decompressed.Append(last);
				}
				last = c;
			}
		}
		return decompressed.ToString();
	}
}