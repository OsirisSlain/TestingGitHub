using System;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		//var inputString = args[0];
		//Console.WriteLine(CompressString(inputString));
		Console.WriteLine(Compress("aaaaa22222222222222222222222bbbbbccccc."));
		Console.WriteLine(Compress("5-29"));
	}
	
	static string Compress(string original)
	{
		var repeat = 1;
		char? last = null;
		bool escapeMode = false;
		var escapeChar = '-';
		var compressed = new StringBuilder();
		
		Action write = () =>{
			compressed.Append(last);
			if(repeat != 1) compressed.Append(repeat);
		};
		
		foreach (var c in original)
		{
			if(c == escapeChar || char.IsDigit(c))
			{
				compressed.Append(string.Format("{0}{1}",escapeChar,c));
				continue;
			}
			if (c == last)
				repeat++;
			else
			{
				write();
				repeat = 1;
				last = c;
			}
		}
		write();
		return compressed.ToString();
	}
}