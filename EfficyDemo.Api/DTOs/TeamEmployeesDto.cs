namespace EfficyDemo.Api.DTOs
{
    public class EmployeeStepsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSteps { get; set; }
    }

    public class TeamEmployeesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeStepsDto> EmployeesSteps { get; set; }
    }
}
