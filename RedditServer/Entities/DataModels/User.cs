using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("user")]
public class User : AuditableEntity<Guid>
{
    [Column("username", TypeName = "VARCHAR(20)")]
    public string Username { get; set; } = string.Empty;

    [Column("email", TypeName = "VARCHAR(255)")]
    public string Email { get; set; } = string.Empty;

    [Column("password", TypeName = "VARCHAR(100)")]
    public string Password { get; set; } = string.Empty;

    [Column("status")]
    public UserStatusType Status { get; set; }

    [Column("refresh_token", TypeName = "VARCHAR(100)")]
    public string? RefreshToken { get; set; }

    [Column("refresh_token_expiration_time")]
    public DateTimeOffset? RefreshTokenExpirationTime { get; set; }
}
