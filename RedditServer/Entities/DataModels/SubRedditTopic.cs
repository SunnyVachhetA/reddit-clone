using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

[Table("subreddit_topic")]
public class SubRedditTopic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title", TypeName = "VARCHAR(255)")]
    public string Title { get; set; } = null!;
}
