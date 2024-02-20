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
	        try
	        {
		        var response = await _httpClient.GetFromJsonAsync<List<ProjectModel>>("projects");
		        return response;
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
		        return new List<ProjectModel>();
	        }
        }

        public async Task<ProjectModel> GetByIdAsync(Guid id)
        {
	        try
	        {
		        var response = await _httpClient.GetFromJsonAsync<ProjectModel>($"projects/{id}");
		        return response;
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
		        return new ProjectModel();
	        }
        }

        public async Task AddAsync(ProjectModel entity)
        {
	        try
	        {
		        await _httpClient.PostAsJsonAsync("projects", entity);
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
	        }
        }

        public async Task DeleteAsync(Guid id)
        {
	        try
	        {
		        await _httpClient.DeleteAsync($"projects/{id}");
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
	        }
        }

        public async Task UpdateAsync(ProjectModel entity)
        {
	        try
	        {
		        await _httpClient.PutAsJsonAsync("projects", entity);
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
	        }
        }
    }
}
