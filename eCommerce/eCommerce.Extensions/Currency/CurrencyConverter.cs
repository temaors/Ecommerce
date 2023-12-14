using System.Net.Http.Json;
using System.Text.Json;

namespace eCommerce.Extensions.Currency;

public static class CurrencyConverter
{
    private const string ApiUrl = "https://api.exchangerate-api.com/v4/latest/BYN";
    public static double ExchangeRate { get; set; } = 1;

    public static async void UpdateExchangeRate(string currencyCode)
    {
        HttpClient client = new HttpClient();
        JsonElement response = await client.GetFromJsonAsync<JsonElement>(ApiUrl);
        ExchangeRate = response.GetProperty("rates").GetProperty(currencyCode).GetDouble();
    }
}