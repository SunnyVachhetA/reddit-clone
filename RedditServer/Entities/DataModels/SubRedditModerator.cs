using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("subreddit_moderator")]
public class SubRedditModerator : AuditableEntity<long>
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("subreddit_id")]
    public long SubRedditId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User Moderator { get; set; } = null!;

    [ForeignKey(nameof(SubRedditId))]
    public virtual SubReddit SubReddit { get; set; } = null!;

    [Column("status")]
    public ModeratorStatus Status { get; set; }
}