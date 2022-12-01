namespace Core;
public class InputFetcher
{
	private readonly HttpClient _httpClient;
	private readonly string _baseAddress = "https://adventofcode.com/";
	private readonly string _dayAddress = "2022/day/{0}/input";


	public InputFetcher(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_httpClient.DefaultRequestHeaders.Clear();
		_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
	}

	public async Task<string?> GetByDay(int day = 1)
	{
		try
		{
			var url = _baseAddress + string.Format(_dayAddress, day);

			var result = await _httpClient.GetStringAsync(url);
			return result;
		}
		catch (Exception ex)
		{
			throw;
		}
	}
}
