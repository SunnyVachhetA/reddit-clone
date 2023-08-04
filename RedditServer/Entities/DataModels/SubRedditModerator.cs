using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("tbSubRedditModerator")]
public class SubRedditModerator : AuditableEntity<long>
{
    public Guid UserId { get; set; }

    public Guid SubRedditId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(SubRedditId))]
    public virtual SubReddit SubReddit { get; set; } = null!;

    public ModeratorStatus Status { get; set; }
}