using System;
using System.Collections.Generic;

namespace weather.Domain
{

	public class Item
	{
		public string title { get; set; }
		public string lat { get; set; }
		public string @long { get; set; }
		public string link { get; set; }
		public string pubDate { get; set; }
		public Condition condition { get; set; }
		public string description { get; set; }
		public List<Forecast> forecast { get; set; }
		public Guid guid { get; set; }
	}
	
}
