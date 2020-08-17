using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{ 
	/// <summary>
	/// LRU cache system
	/// 
	/// </summary>
  class Program
  {
    static void Main(string[] args)
    { // Testing the Component
			var cache = new LRU_Cache();
			for (int i = 0; i < 20; i++)
			{
				var query = "query" + i;
				// insert into the cache
				cache.insertResults(query, generateResults(i));
				if (i == 9 || i == 16 || i == 19)
				{
					cache.getResults("query" + 2);
					cache.getResults("query" + 6);
					cache.getResults("query" + 9);
				}
			}


			// Get from the cache to see result
			for (int i = 0; i < 30; i++)
			{
				var query = "query" + i;
		  	var results = cache.getResults(query);
        Console.Write(query + ": ");
				if (results == null)
				{
					Console.WriteLine("null");
				}
				else
				{
					foreach (string s in results)
					{
						Console.Write(s + ", ");
					}
				}
				Console.Write("");
			}
			Console.ReadLine();
		}
    public static string[] generateResults(int i)
    {
      var results =  new[]{ "resultA" + i, "resultB" + i, "resultC" + i, "resultD" + i };
      return results;
    }
  }
}
