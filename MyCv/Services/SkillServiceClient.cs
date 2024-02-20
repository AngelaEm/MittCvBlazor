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
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>("skills");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new List<SkillModel>();
	    }
    }

    public async Task<SkillModel> GetByIdAsync(Guid id)
    {
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<SkillModel>($"skills/{id}");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new SkillModel();
	    }
    }

    public async Task AddAsync(SkillModel entity)
    {
	    try
	    {
		    await _httpClient.PostAsJsonAsync("skills", entity);
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
		    await _httpClient.DeleteAsync($"skills/{id}");
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }

    public async Task UpdateAsync(SkillModel entity)
    {
	    try
	    {
		    await _httpClient.PutAsJsonAsync("skills", entity);
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }
}