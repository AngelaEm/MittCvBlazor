using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCv.Components;
using MyCv.Components.Account;
using MyCv.Data;
using MyCv.Services.Interfaces;
using MyCv.Services;
using MyCv.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!)
});

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IWorkExperienceService, WorkExperienceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();


app.MapGet("/educations", async (IEducationService educationService) =>
{
    var educations = await educationService.GetAllAsync();
    if (educations != null)
    {
        return Results.Ok(educations);
    }
    else
    {
        return Results.NotFound("Sorry, no educations found!");
    }
});

app.MapGet("/educations/{id:guid}", async (Guid id, IEducationService educationService) =>
{
    var education = await educationService.GetByIdAsync(id);
    if (education != null)
    {
        return Results.Ok(education);
    }
    else
    {
        return Results.NotFound("Sorry, no educations found!");
    }
});

app.MapPost("/educations", async (EducationModel education, IEducationService educationService) =>
{
    await educationService.AddAsync(education);
    return Results.Ok(education);
});

app.MapDelete("/educations/{id:guid}", async (Guid id, IEducationService educationService) =>
{
    await educationService.DeleteAsync(id);
    return Results.Ok("Successfully deleted!");
});


app.MapPut("/educations/{id:guid}", async (EducationModel updatedEducation, IEducationService educationService) =>
{
    await educationService.UpdateAsync(updatedEducation);
    return Results.Ok("Successfully updated!");
});

app.MapGet("/projects", async (IProjectService projectService) =>
{
    var projects = await projectService.GetAllAsync();
    if (projects != null)
    {
        return Results.Ok(projects);
    }
    else
    {
        return Results.NotFound("Sorry, no projects found!");
    }
});

app.MapGet("/projects/{id:guid}", async (Guid id, IProjectService projectService) =>
{
    var project = await projectService.GetByIdAsync(id);
    if (project != null)
    {
        return Results.Ok(project);
    }
    else
    {
        return Results.NotFound("Sorry, project not found!");
    }
});

app.MapPost("/projects", async (ProjectModel project, IProjectService projectService) =>
{
    await projectService.AddAsync(project);
    return Results.Ok(project);
});

app.MapDelete("/projects/{id:guid}", async (Guid id, IProjectService projectService) =>
{
    await projectService.DeleteAsync(id);
    return Results.Ok("Successfully deleted");
});

app.MapPut("/projects/{id:guid}", async (ProjectModel project, IProjectService projectService) =>
{
    await projectService.UpdateAsync(project);
    return Results.Ok("Successfully updated!");
});

app.MapGet("/skills", async (ISkillService skillService) =>
{
    var skills = await skillService.GetAllAsync();
    if (skills != null)
    {
        return Results.Ok(skills);
    }
    else
    {
        return Results.NotFound("Sorry, no projects found!");
    }
});

app.MapGet("/skills/{id:guid}", async (Guid id, ISkillService skillService) =>
{
    var skills = await skillService.GetByIdAsync(id);
    if (skills != null)
    {
        return Results.Ok(skills);
    }
    else
    {
        return Results.NotFound("Sorry, no projects found!");
    }
});

app.MapPost("/skills", async (SkillModel skill, ISkillService skillService) =>
{
    await skillService.AddAsync(skill);
    return Results.Ok("Successfully posted!");
});

app.MapDelete("/skills/{id:guid}", async (Guid id, ISkillService skillService) =>
{
    await skillService.DeleteAsync(id);
    return Results.Ok("Successfully deleted!");
});

app.MapPut("/skills/{id:guid}", async (SkillModel skill, ISkillService skillService) =>
{
    await skillService.UpdateAsync(skill);
    return Results.Ok("Successfully updated!");
});

app.MapGet("/workExperience", async (IWorkExperienceService workExperienceService) =>
{
    var workExperience = await workExperienceService.GetAllAsync();
    if (workExperience != null)
    {
        return Results.Ok(workExperience);
    }
    else
    {
        return Results.NotFound("WorkExperience not found!");
    }
});

app.MapGet("/workExperience/{id:guid}", async (Guid id, IWorkExperienceService workExperienceService) =>
{
    var workExperience = await workExperienceService.GetByIdAsync(id);
    if (workExperience != null)
    {
        return Results.Ok(workExperience);
    }
    else
    {
        return Results.NotFound("Sorry, workExperience not found!");
    }
});

app.MapPost("/workExperience", async (WorkExperienceModel workExperience, IWorkExperienceService workExperienceService) =>
{
    await workExperienceService.AddAsync(workExperience);
    return Results.Ok("Successfully added!");
});

app.MapDelete("/workExperience/{id:guid}", async (Guid id, IWorkExperienceService workexperienceService) =>
{
    await workexperienceService.DeleteAsync(id);
    return Results.Ok("Successfully deleted!");
});

app.MapPut("/workExperience/{id:guid}", async (WorkExperienceModel workexperience, IWorkExperienceService workExperienceService) =>
{
    await workExperienceService.UpdateAsync(workexperience);
    return Results.Ok("Successfully updated");
});

app.Run();
