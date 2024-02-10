namespace MyCv.Models
{
    public class WorkExperienceModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Location { get; set; }
        public string WorkDescription { get; set; }
    }
}
