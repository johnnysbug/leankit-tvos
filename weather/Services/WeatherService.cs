using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using weather.Domain;
using System.Linq;

namespace weather.Services
{
	public static class WeatherService
	{
		private const string WEATHER_URL = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22nashville%2C%20tn%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
		private const string CONDITION_URL_FORMAT = "http://l.yimg.com/a/i/us/we/52/{0}.gif";

		public static async Task<Weather> Get()
		{
			var handler = new HttpClientHandler {
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
			};

			var client = new HttpClient(handler);

			var response = await client.GetAsync(WEATHER_URL);

			var s = new DataContractJsonSerializer(typeof(RootObject));

			var o = s.ReadObject(await response.Content.ReadAsStreamAsync()) as RootObject;

			var channel = o.query.results.channel;

			var location = channel.location;
			var currentConditions = channel.item.condition;
			var astronomy = channel.astronomy;
			var forecast = channel.item.forecast;

			var weather = new Weather {
				CurrentCondition = currentConditions.text,
				CurrentTemperature = currentConditions.temp,
				Location = string.Format("{0}, {1}", location.city, location.region),
				Sunrise = astronomy.sunrise,
				Sunset = astronomy.sunset,
				Forecast = forecast.Select(f => new Weather.DailyCondition(f.day, f.high, f.low, f.text, f.code)).ToList()
			};

			return weather;
		}
	}
}

