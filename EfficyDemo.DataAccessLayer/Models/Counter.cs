using System.Text.Json.Serialization;

namespace EfficyDemo.DAL.Models
{
    public class Counter
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int EmployeeId { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Employee Employee { get; set; }
    }
}
