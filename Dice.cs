using System;

class Dice
{
	static Random _rand = new Random();
	
	public static int Roll2d6()
	{
		return Roll(1,6,2);
	}
	
	//both bounds inclusive
	public static int Roll(int low, int high, int count)
	{
		int result = 0;
		for(int ii = 0; ii < count; ii++)
		{
			result += _rand.Next(low, high + 1);
		}
		return result;
	}
}