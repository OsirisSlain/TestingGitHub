using System;

public class ArgParse
{
	public static bool TryInt(string[] args, out int result)
	{
		var valid = tryInt(args, out result);
		if(!valid)
			Console.WriteLine("Input Error");
		return valid;
	}
	private static bool tryInt(string[] args, out int result)
	{
		result = 0;
		if (args.Length < 1)
			return false;
		if(!int.TryParse(args[0], out result))
			return false;
		if(result < 0)
			return false;
		return true;
	}
}