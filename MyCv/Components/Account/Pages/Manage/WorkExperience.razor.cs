using Common.Models;
using Microsoft.AspNetCore.Components;

namespace MyCv.Components.Account.Pages.Manage;

public partial class WorkExperience
{
	private WorkExperienceModel newWorkExperience = new();
	private List<WorkExperienceModel> workExperience = new();

	protected override async Task OnInitializedAsync()
	{
		try
		{
			workExperience.AddRange(await WorkExperienceService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	private async Task OnWorkExperienceSelected(ChangeEventArgs e)
	{
		Guid.TryParse(e.Value?.ToString(), out Guid workId);

		if (workId == Guid.Empty)
		{
			newWorkExperience = new WorkExperienceModel();
		}
		else
		{
			newWorkExperience = await WorkExperienceService.GetByIdAsync(workId);
		}
	}

	private async Task HandleValidSubmit()
	{
		if (newWorkExperience.Id == Guid.Empty)
		{
			await WorkExperienceService.AddAsync(newWorkExperience);
		}
		else
		{
			await WorkExperienceService.UpdateAsync(newWorkExperience);
		}

		workExperience.Clear();
		workExperience.AddRange(await WorkExperienceService.GetAllAsync());
		newWorkExperience = new WorkExperienceModel();
	}

	private async Task DeleteWorkExperience()
	{
		if (newWorkExperience != null && newWorkExperience.Id != Guid.Empty)
		{
			await WorkExperienceService.DeleteAsync(newWorkExperience.Id);
			workExperience.Clear();
			workExperience.AddRange(await WorkExperienceService.GetAllAsync());
			newWorkExperience = new WorkExperienceModel();
		}
	}
}