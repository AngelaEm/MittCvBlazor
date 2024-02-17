namespace Common.Models
{
    public class EducationModel
    {
        public Guid Id { get; set; }
        public string InstitutionName { get; set; }
        public string EducationName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
