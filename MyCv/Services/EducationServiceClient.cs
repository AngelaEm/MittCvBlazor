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
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<List<EducationModel>>("/educations");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new List<EducationModel>();
	    }
    }

    public async Task<EducationModel> GetByIdAsync(Guid id)
    {
	    try
	    {
		    var response = await _httpClient.GetFromJsonAsync<EducationModel>($"educations/{id}");
		    return response;
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
		    return new EducationModel();
	    }
       
    }

    public async Task AddAsync(EducationModel entity)
    {
	    try
	    {
		    await _httpClient.PostAsJsonAsync("educations", entity);
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
		    await _httpClient.DeleteAsync($"educations/{id}");
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }

    public async Task UpdateAsync(EducationModel entity)
    {
	    try
	    {
		    await _httpClient.PutAsJsonAsync("educations", entity);
		}
	    catch (Exception e)
	    {
		    Console.WriteLine(e.Message);
	    }
    }
}