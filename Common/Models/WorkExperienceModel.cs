using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class WorkExperienceModel
    {
        public Guid Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateOnly? StartDate { get; set; }
        [Required]
        public DateOnly? EndDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string WorkDescription { get; set; }
    }
}
