using Common.Enums;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class SubRedditTopicConfiguration
    : IEntityTypeConfiguration<SubRedditTopic>
{
    public void Configure(EntityTypeBuilder<SubRedditTopic> builder)
    {
        builder.HasIndex(model => new { model.TopicId, model.SubRedditId })
            .IsUnique();

        builder.HasOne(model => model.SubReddit)
               .WithMany(subreddit => subreddit.Topics)
               .HasForeignKey(model => model.SubRedditId);

        builder.HasOne(model => model.Topic)
               .WithMany(topic => topic.SubReddits)
               .HasForeignKey(model => model.TopicId);

        builder.Property(model => model.Status)
            .HasDefaultValue(SubRedditTopicStatus.Active);
    }
}