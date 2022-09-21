using System.ComponentModel.DataAnnotations;

namespace CafeSimpleManagementSystem.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedDate { get; set; }
}