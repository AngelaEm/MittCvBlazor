using Common.Models;
using Microsoft.AspNetCore.Components;

namespace MyCv.Components.Account.Pages.Manage;

public partial class Projects
{
	public ProjectModel? newProject = new();
	private List<ProjectModel> projects = new();

	protected override async Task OnInitializedAsync()
	{
		try
		{
			projects.AddRange(await ProjectService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	private async Task OnProjectSelected(ChangeEventArgs e)
	{
		Guid.TryParse(e.Value?.ToString(), out Guid educationId);

		if (educationId == Guid.Empty)
		{
			newProject = new ProjectModel();
		}
		else
		{
			newProject = await ProjectService.GetByIdAsync(educationId);
		}
	}

	private async Task HandleValidSubmit()
	{
		if (newProject.Id == Guid.Empty)
		{
			await ProjectService.AddAsync(newProject);
		}
		else
		{
			await ProjectService.UpdateAsync(newProject);
		}

		projects.Clear();
		projects.AddRange(await ProjectService.GetAllAsync());
		newProject = new ProjectModel();
	}

	private async Task DeleteProject()
	{
		if (newProject != null && newProject.Id != Guid.Empty)
		{
			await ProjectService.DeleteAsync(newProject.Id);
			projects.Clear();
			projects.AddRange(await ProjectService.GetAllAsync());
			newProject = new ProjectModel();
		}
	}
}