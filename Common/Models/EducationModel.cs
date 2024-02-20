using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class EducationModel
    {
        public Guid Id { get; set; }
        [Required]
        public string InstitutionName { get; set; }
        [Required]
        public string EducationName { get; set; }
        [Required]
        public DateOnly? StartDate { get; set; }
        [Required]
        public DateOnly? EndDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
