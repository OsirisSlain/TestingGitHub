using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		var cache = new LruCache<int,int>(getNum, 7);
		for (int i = 0; i < 10; i++)
			Console.Write(cache.GetItem(i) + " ");
		for (int i = 9; i >= 0; i--)
			Console.Write(cache.GetItem(i) + " ");
		for (int i = 0; i < 10; i++)
			Console.Write(cache.GetItem(i) + " ");
		Console.WriteLine();
	}
	
	static int getNum(int num)
	{
		Console.Write("X"); //signifies cache miss
		return num;
	}
}

class LruCache<TKey, TVal>
{
	int _cacheSize;
	Func<TKey, TVal> _getUncached;
	Dictionary<TKey, TVal> _cache;
	List<Tuple<TKey, DateTime>> _accessTimes;
	
	public LruCache(Func<TKey, TVal> getUncached, int cacheSize)
	{
		_cacheSize = cacheSize;
		_getUncached = getUncached;
		Clear();
	}
	
	public void Clear()
	{
		_cache = new Dictionary<TKey, TVal>();
		_accessTimes = new List<Tuple<TKey, DateTime>>();
	}
	
	private void trimCache()
	{
		if(_cache.Count > _cacheSize)
		{
			_accessTimes.Sort((y,x) => x.Item2.CompareTo(y.Item2));
			var leastUsed = _accessTimes[_accessTimes.Count - 1];
			_cache.Remove(leastUsed.Item1);
			_accessTimes.Remove(leastUsed);
		}
	}
	
	public TVal GetItem(TKey key)
	{
		TVal item;
		if(!_cache.TryGetValue(key, out item))
		{
			 item = _getUncached(key);
			 _cache.Add(key, item);
		}
		_accessTimes.RemoveAll(x => x.Item1.Equals(key));
		_accessTimes.Add(Tuple.Create(key, DateTime.Now));
		trimCache();
		return item;
	}
}
