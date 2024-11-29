using System.Text.Json.Serialization;

namespace EfficyDemo.DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Employee> Employees { get; set; }
    }
}
