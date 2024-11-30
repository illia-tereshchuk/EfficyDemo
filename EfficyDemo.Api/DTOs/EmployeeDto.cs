namespace EfficyDemo.Api.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TotalSteps { get; set; }
    }
}
