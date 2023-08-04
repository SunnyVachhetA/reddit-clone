using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("tbRedditTopic")]
public class RedditTopic : IdentityEntity<int>
{
    [Column(TypeName = "VARCHAR(255)")]
    public string Title { get; set; } = null!;

    public virtual ICollection<SubRedditTopic> SubReddits { get; set; } = new List<SubRedditTopic>();
}
