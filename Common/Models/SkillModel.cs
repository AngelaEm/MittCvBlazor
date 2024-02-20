using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class SkillModel
    {
        public Guid Id { get; set; }
        [Required]
        public string TechnologyName { get; set; }
        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public int SkillLevel { get; set; }
    }
}
