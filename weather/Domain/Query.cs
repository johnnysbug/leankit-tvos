using System;
using System.Collections.Generic;

namespace weather.Domain
{

	public class Query
	{
		public int count { get; set; }
		public string created { get; set; }
		public string lang { get; set; }
		public Results results { get; set; }
	}
	
}
