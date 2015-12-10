using System;
using System.Collections.Generic;

namespace weather.Domain
{

	public class Forecast
	{
		public string code { get; set; }
		public string date { get; set; }
		public string day { get; set; }
		public string high { get; set; }
		public string low { get; set; }
		public string text { get; set; }
	}
	
}
