using Common.Models;

namespace MyCv.Components.Pages;

public partial class Home
{
	private List<EducationModel> educations = new();
	private List<WorkExperienceModel> workExperience = new();
	private List<SkillModel> skills = new();
	private List<ProjectModel> projects = new();
	public AdviceModel? AdviceModel { get; set; } = new();
	private string currentUrl = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

		try
		{
			educations.AddRange(await EducationService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine($"Failed to load educations: {e.Message}");
		}

		try
		{
			workExperience.AddRange(await WorkService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine($"Failed to load work experiences: {e.Message}");
		}

		try
		{
			projects.AddRange(await ProjectService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine($"Failed to load projects: {e.Message}");
		}

		try
		{
			skills.AddRange(await SkillService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine($"Failed to load skills: {e.Message}");
		}

		try
		{
			var client = ClientFactory.CreateClient("adviceApi");
			AdviceModel = await client.GetFromJsonAsync<AdviceModel>("/advice");
		}
		catch (Exception e)
		{
			Console.WriteLine($"Failed to load advice: {e.Message}");
			AdviceModel = null; 
		}
	}
}
