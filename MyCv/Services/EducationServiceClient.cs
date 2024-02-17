using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Components;
using MyCv.Components.Account.Pages.Manage;

namespace MyCv.Services;

public class EducationServiceClient : IEducationService
{
    private readonly HttpClient _httpClient;

    public EducationServiceClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("mittApi");
    }

    public async Task<IEnumerable<EducationModel>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<EducationModel>>("/educations");
        return response;
    }

    public async Task<EducationModel> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<EducationModel>($"educations/{id}");
        return response;
    }

    public async Task AddAsync(EducationModel entity)
    {
        await _httpClient.PostAsJsonAsync("educations", entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"educations/{id}");
    }

    public async Task UpdateAsync(EducationModel entity)
    {
        await _httpClient.PutAsJsonAsync("educations", entity);
       
    }

}