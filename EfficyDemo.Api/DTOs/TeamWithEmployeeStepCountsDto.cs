namespace EfficyDemo.Api.DTOs
{
    public class TeamWithEmployeeStepCountsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeStepCountDto> Employees { get; set; }
    }
}
