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
    public async Task<IEnumerable<WorkExperienceModel>> GetAllAsync()
    {
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<List<WorkExperienceModel>>("/workExperience");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new List<WorkExperienceModel>();
	    }
    }
    public async Task<WorkExperienceModel> GetByIdAsync(Guid id)
    {
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<WorkExperienceModel>($"workExperience/{id}");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new WorkExperienceModel();
	    }
    }
	public async Task AddAsync(WorkExperienceModel entity)
    {
	    try
	    {
		    await _httpClient.PostAsJsonAsync("workExperience", entity);
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
		    await _httpClient.DeleteAsync($"workExperience/{id}");
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }

    public async Task UpdateAsync(WorkExperienceModel entity)
    {
	    try
	    {
		    await _httpClient.PutAsJsonAsync("workExperience", entity);
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }
}