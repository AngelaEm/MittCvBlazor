using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace MyCvApi.Data
{
    public class ApiDbContext : DbContext 
    {
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<EducationModel> Educations { get; set; }
        public DbSet<WorkExperienceModel> WorkExperience { get; set; }

        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
