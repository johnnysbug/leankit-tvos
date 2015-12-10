using System;
using System.Collections.Generic;

namespace weather.Domain
{

	public class Weather
	{
		private const string CONDITION_URL_FORMAT = "http://l.yimg.com/a/i/us/we/52/{0}.gif";

		public string Location { get; set; }
		public string CurrentTemperature { get; set; }
		public string CurrentCondition { get; set; }
		public string Sunrise { get; set; }
		public string Sunset { get; set; }
		public List<DailyCondition> Forecast { get; set; }

		public class DailyCondition
		{
			private readonly string code;

			public DailyCondition(string day, string high, string low, string condition, string code)
			{
				Day = day;
				High = high;
				Low = low;
				Condition = condition;
				this.code = code;
			}

			public string Day { get; private set; }
			public string High { get; private set; }
			public string Low { get; private set; }
			public string Condition { get; private set; }
			public string ImageUrl
			{
				get
				{
					return string.Format(CONDITION_URL_FORMAT, code);
				}
			}
			public override string ToString()
			{
				return string.Format("[DailyCondition: Day={0}, High={1}, Low={2}, Condition={3}, ImageUrl={4}]", Day, High, Low, Condition, ImageUrl);
			}
		}

		public override string ToString()
		{
			return string.Format("[Weather: Location={0}, CurrentTemperature={1}, CurrentCondition={2}, Sunrise={3}, Sunset={4}, Forecast={5}]", Location, CurrentTemperature, CurrentCondition, Sunrise, Sunset, Forecast);
		}
	}
}
