using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TechnologiesUsed { get; set; }
        [Required]
        public string ProjectLink { get; set; }
    }
}
