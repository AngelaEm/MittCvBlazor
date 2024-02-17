using Common.Interfaces;
using Common.Models;

namespace MyCv.Services;

public class SkillServiceClient : ISkillService
{
    private readonly HttpClient _httpClient;

    public SkillServiceClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("mittApi");
    }

    public async Task<IEnumerable<SkillModel>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>("skills");
        return response;
    }

    public async Task<SkillModel> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<SkillModel>($"skills/{id}");
        return response;
    }

    public async Task AddAsync(SkillModel entity)
    {
        await _httpClient.PostAsJsonAsync("skills", entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"skills/{id}");
    }

    public async Task UpdateAsync(SkillModel entity)
    {
        await _httpClient.PutAsJsonAsync("skills", entity);
    }

   
}