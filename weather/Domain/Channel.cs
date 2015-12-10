using System;
using System.Collections.Generic;

namespace weather.Domain
{

	public class Channel
	{
		public string title { get; set; }
		public string link { get; set; }
		public string description { get; set; }
		public string language { get; set; }
		public string lastBuildDate { get; set; }
		public string ttl { get; set; }
		public Location location { get; set; }
		public Units units { get; set; }
		public Wind wind { get; set; }
		public Atmosphere atmosphere { get; set; }
		public Astronomy astronomy { get; set; }
		public Image image { get; set; }
		public Item item { get; set; }
	}
	
}
