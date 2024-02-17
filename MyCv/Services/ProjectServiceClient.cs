using System.Net.Http;
using Common.Interfaces;
using Common.Models;

namespace MyCv.Services
{
    
    public class ProjectServiceClient : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectServiceClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("mittApi");
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProjectModel>>("projects");
            return response;
        }

        public async Task<ProjectModel> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<ProjectModel>($"projects/{id}");
            return response;
        }

        public async Task AddAsync(ProjectModel entity)
        {
            await _httpClient.PostAsJsonAsync("projects", entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"projects/{id}");
        }

        public async Task UpdateAsync(ProjectModel entity)
        {
            await _httpClient.PutAsJsonAsync("projects", entity);
        }

       
    }
}

