using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("tbSubReddit")]
public class SubReddit : AuditableEntity<Guid>
{
    [Column(TypeName = "VARCHAR(255)")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "VARCHAR(255)")]
    public string Slug { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Banner { get; set; } = null!;

    public Guid CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public virtual User CreatedBy { get; set; } = null!;

    [Column(TypeName = "VARCHAR(MAX)")]
    public string Description { get; set; } = null!;

    public SubRedditStatusType Status { get; set; }

    public SubRedditType Type { get; set; }

    public long MemberCount { get; set; }

    public virtual ICollection<SubRedditTopic> Topics { get; set; } = new List<SubRedditTopic>();

    public virtual ICollection<SubRedditModerator> Moderators { get; set; } = new List<SubRedditModerator>();
}
