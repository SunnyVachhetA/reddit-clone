using Common.Enums;
using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("tbSubRedditTopic")]
public class SubRedditTopic : AuditableEntity<long>
{
    public Guid SubRedditId { get; set; }

    [ForeignKey(nameof(SubRedditId))]
    public virtual SubReddit SubReddit { get; set; } = null!;

    public int TopicId { get; set; }

    [ForeignKey(nameof(TopicId))]
    public virtual RedditTopic Topic { get; set; } = null!;

    public SubRedditTopicStatus Status { get; set; }
}
