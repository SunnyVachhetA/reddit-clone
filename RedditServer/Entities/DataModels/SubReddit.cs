using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("sub_reddit")]
public class SubReddit : AuditableEntity<long>
{
    [Column("title", TypeName = "VARCHAR(255)")]
    public string Title { get; set; } = null!;

    [Column("slug", TypeName = "VARCHAR(255)")]
    public string Slug { get; set; } = null!;

    [Column("icon")]
    public string Icon { get; set; } = null!;

    [Column("banner")]
    public string Banner { get; set; } = null!;

    [Column("created_by")]
    public Guid CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public virtual User CreatedBy { get; set; } = null!;

    [Column("description", TypeName = "VARCHAR(MAX)")]
    public string Description { get; set; } = null!;

    [Column("status")]
    public SubRedditStatusType Status { get; set; } = SubRedditStatusType.Active;

    [Column("type")]
    public SubRedditType Type { get; set; } = SubRedditType.Public;

    public long MemberCount { get; set; }

    public virtual ICollection<SubRedditTopic> Topics { get; set; } = new List<SubRedditTopic>();

    public virtual ICollection<SubRedditModerator> Moderators { get; set; } = new List<SubRedditModerator>();
}
