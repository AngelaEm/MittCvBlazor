using Common.Interfaces;
using Common.Models;

namespace MyCv.Services;

public class WorkExperiensServiceClient : IWorkExperienceService
{
    private readonly HttpClient _httpClient;

    public WorkExperiensServiceClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("mittApi");
    }

    public async Task AddAsync(WorkExperienceModel entity)
    {
        await _httpClient.PostAsJsonAsync("workExperience", entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"workExperience/{id}");
    }

    public async Task<IEnumerable<WorkExperienceModel>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<WorkExperienceModel>>("/workExperience");
        return response;
    }


    public async Task<WorkExperienceModel> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<WorkExperienceModel>($"workExperience/{id}");
        return response;
    }

    public async Task UpdateAsync(WorkExperienceModel entity)
    {
        await _httpClient.PutAsJsonAsync("workExperience", entity);

    }

}