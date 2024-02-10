using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCv.Models;

namespace MyCv.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<EducationModel> Educations { get; set; }
        public DbSet<WorkExperienceModel> WorkExperience { get; set; }
    }
}
