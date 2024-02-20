using Common.Models;
using Microsoft.AspNetCore.Components;

namespace MyCv.Components.Account.Pages.Manage;

public partial class Skills
{
	public SkillModel? newSkill = new();
	private List<SkillModel> skills = new();

	protected override async Task OnInitializedAsync()
	{
		try
		{
			skills.AddRange(await SkillService.GetAllAsync());
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	private async Task OnSkillSelected(ChangeEventArgs e)
	{
		Guid.TryParse(e.Value?.ToString(), out Guid educationId);

		if (educationId == Guid.Empty)
		{
			newSkill = new SkillModel();
		}
		else
		{
			newSkill = await SkillService.GetByIdAsync(educationId);
		}
	}

	private async Task HandleValidSubmit()
	{
		if (newSkill.Id == Guid.Empty)
		{
			await SkillService.AddAsync(newSkill);
		}
		else
		{
			await SkillService.UpdateAsync(newSkill);
		}

		skills.Clear();
		skills.AddRange(await SkillService.GetAllAsync());
		newSkill = new SkillModel();
	}

	private async Task DeleteSkill()
	{
		if (newSkill != null && newSkill.Id != Guid.Empty)
		{
			await SkillService.DeleteAsync(newSkill.Id);
			skills.Clear();
			skills.AddRange(await SkillService.GetAllAsync());
			newSkill = new SkillModel();
		}
	}
}