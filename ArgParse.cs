using System;

//Functions for parsing input arguments
public class ArgParse
{
	//Try to get the first input argument as an int
	public static bool TryInt(string[] args, out int result)
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
	public static bool TryIntVerbose(string[] args, out int result)
	{
		var success = TryInt(args, out result);
		if(!success)
			Console.WriteLine("Input Error");
		return success;
	}
}
