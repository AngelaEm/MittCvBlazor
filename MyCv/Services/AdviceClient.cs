using Common.Models;

namespace MyCv.Services;

public class AdviceClient
{
    private readonly HttpClient _httpClient;

    public AdviceClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("adviceApi");
    }

    public async Task<AdviceModel> GetAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<AdviceModel>("/advice");
        return response;
    }
}