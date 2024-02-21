using Microsoft.EntityFrameworkCore;
using MyCvApi.Data;
using Common.Interfaces;
using Common.Models;
using MyCvApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEducationService, EducationRepository>();
builder.Services.AddScoped<IWorkExperienceService, WorkExperienceRepository>();
builder.Services.AddScoped<IProjectService, ProjectRepository>();
builder.Services.AddScoped<ISkillService, SkillRepository>();


var app = builder.Build();

//Educations
app.MapGet("/educations", async (IEducationService service) => await service.GetAllAsync());

app.MapGet("/educations/{id}", async (Guid id, IEducationService service) => await service.GetByIdAsync(id));

app.MapPost("/educations", async (IEducationService service, EducationModel education) => await service.AddAsync(education));

app.MapDelete("/educations/{id}", async (Guid id, IEducationService service) => await service.DeleteAsync(id));

app.MapPut("/educations", async (IEducationService service, EducationModel education) => await service.UpdateAsync(education));

//Workexperience
app.MapGet("/workExperience", async (IWorkExperienceService service) => await service.GetAllAsync());

app.MapGet("/workExperience/{id}", async (Guid id, IWorkExperienceService service) => await service.GetByIdAsync(id));

app.MapPost("/workExperience", async (IWorkExperienceService service, WorkExperienceModel work) => await service.AddAsync(work));

app.MapDelete("/workExperience/{id}", async (Guid id, IWorkExperienceService service) => await service.DeleteAsync(id));

app.MapPut("/workExperience", async (IWorkExperienceService service, WorkExperienceModel work) => await service.UpdateAsync(work));

//Projects
app.MapGet("/projects", async (IProjectService service) => await service.GetAllAsync());

app.MapGet("/projects/{id}", async (Guid id, IProjectService service) => await service.GetByIdAsync(id));

app.MapPost("/projects", async (IProjectService service, ProjectModel project) => service.AddAsync(project));

app.MapDelete("/projects/{id}", async (Guid id, IProjectService service) => await service.DeleteAsync(id));

app.MapPut("/projects", async (IProjectService service, ProjectModel project) => await service.UpdateAsync(project));

//Skills
app.MapGet("/skills", async (ISkillService service) => await service.GetAllAsync());

app.MapGet("/skills/{id}", async (Guid id, ISkillService service) => await service.GetByIdAsync(id));

app.MapPost("/skills", async (ISkillService service, SkillModel skill) => await service.AddAsync(skill));

app.MapDelete("/skills/{id}", async (Guid id, ISkillService service) => await service.DeleteAsync(id));

app.MapPut("/skills", async (ISkillService service, SkillModel skill) => await service.UpdateAsync(skill));

app.Run();
