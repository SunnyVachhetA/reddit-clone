using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("tbUser")]
public class User : AuditableEntity<Guid>
{
    [Column(TypeName = "VARCHAR(20)")]
    public string Username { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(255)")]
    public string Email { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(100)")]
    public string Password { get; set; } = string.Empty;

    public string Avatar { get; set; } = null!;

    public UserStatusType Status { get; set; }

    [Column(TypeName = "VARCHAR(100)")]
    public string? RefreshToken { get; set; }

    public DateTimeOffset? RefreshTokenExpirationTime { get; set; }

    public virtual ICollection<SubRedditModerator> SubRedditModerators { get; set; } = new List<SubRedditModerator>();
}
