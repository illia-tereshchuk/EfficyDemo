namespace EfficyDemo.Api.DTOs
{
    public class EmployeeStepCountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSteps { get; set; }
    }

    public class TeamEmployeesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeStepCountDto> Employees { get; set; }
    }
}
