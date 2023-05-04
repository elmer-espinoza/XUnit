using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Api.Data.Entities;

[Table(name: "ToDo")]
public class Todo
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    public bool IsCompleted { get; set; }
}