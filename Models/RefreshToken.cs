using System.ComponentModel.DataAnnotations;

namespace CafeSimpleManagementSystem.Models;

public class RefreshToken
{
    [Key]
    public Guid Id { get; set; }
    public Guid Token { get; set; }
    public DateTime ExpiredDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

}