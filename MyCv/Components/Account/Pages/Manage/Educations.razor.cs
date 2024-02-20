using Common.Models;
using Microsoft.AspNetCore.Components;

namespace MyCv.Components.Account.Pages.Manage;

public partial class Educations
{
	private EducationModel newEducation = new();
	private List<EducationModel> educations = new();

	protected override async Task OnInitializedAsync()
	{
		try
		{
			educations.AddRange(await EducationService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}


	private async Task OnEducationSelected(ChangeEventArgs e)
	{
		Guid.TryParse(e.Value?.ToString(), out Guid educationId);

		if (educationId == Guid.Empty)
		{
			newEducation = new EducationModel();
		}
		else
		{
			newEducation = await EducationService.GetByIdAsync(educationId);
		}
	}

	private async Task HandleValidSubmit()
	{
		if (newEducation.Id == Guid.Empty)
		{
			await EducationService.AddAsync(newEducation);
		}
		else
		{
			await EducationService.UpdateAsync(newEducation);
		}

		educations.Clear();
		educations.AddRange(await EducationService.GetAllAsync());
		newEducation = new EducationModel();
	}

	private async Task DeleteEducation()
	{
		if (newEducation != null && newEducation.Id != Guid.Empty)
		{
			await EducationService.DeleteAsync(newEducation.Id);
			educations.Clear();
			educations.AddRange(await EducationService.GetAllAsync());
			newEducation = new EducationModel();
		}
	}
}