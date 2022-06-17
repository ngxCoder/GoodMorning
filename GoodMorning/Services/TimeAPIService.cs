using System;
using GoodMorning.Models;

namespace GoodMorning.Services
{
	public interface ITimeAPIService
	{
		Task<TimeResponse?> GetTimeAsync();
	}

	public class TimeAPIService : ITimeAPIService
	{
		private readonly HttpClient _httpClient;

		public TimeAPIService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://timeapi.io/api/");
		}


		public async Task<TimeResponse?> GetTimeAsync()
		{
			return await _httpClient.GetFromJsonAsync<TimeResponse>("time/current/zone?timeZone=America/Panama");
		}
	}
}

