using System;
using System.Text;

class Program
{
	static void Main()
	{
		//var inputString = args[0];
		//Console.WriteLine(CompressString(inputString));
		Console.WriteLine(Decompress("A normal string with nothing repeated."));
		Console.WriteLine(Decompress("An almost normal string with -93 (three nines) in the middle."));
		Console.WriteLine(Decompress("23 digits at start."));
		Console.WriteLine(Decompress("-2-3 escaped digits at start."));
		Console.WriteLine(Decompress("lots10 of s10's."));
		Console.WriteLine(Decompress("-533--"));
		Console.WriteLine(Decompress("s5"));
	}
	
	static string Decompress(string compressed)
	{
		var decompressed = new StringBuilder();
		var digits = new StringBuilder();
		char? last = null;
		bool escapeMode = false;
		var escapeChar = '-';
		
		Action write = () => AppendDecompressed(ref digits, decompressed, last);
		
		foreach(var c in compressed)
		{
			if(escapeMode)
			{
				last = c;
				escapeMode = false;
				continue;
			}
			if(c == escapeChar)
			{
				write();
				escapeMode = true;
				continue;
			}
			if(Char.IsDigit(c))
			{
				digits.Append(c);
				continue;
			}
			write();
			last = c;
		}
		write();
		return decompressed.ToString();
	}
	
	static void AppendDecompressed(ref StringBuilder digits, StringBuilder decompressed, char? last)
	{
			int repeat;
			int.TryParse(digits.ToString(), out repeat);
			if (repeat == 0) repeat = 1;
			
			digits = new StringBuilder();
			
			for(int i = 0; i < repeat; i++)
			{
				decompressed.Append(last);
			}
	}
}