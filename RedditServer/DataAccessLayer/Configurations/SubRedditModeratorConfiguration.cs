using Common.Enums;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;
internal class SubRedditModeratorConfiguration
    : IEntityTypeConfiguration<SubRedditModerator>
{
    public void Configure(EntityTypeBuilder<SubRedditModerator> builder)
    {
        builder.Property(model => model.Status)
            .HasDefaultValue(ModeratorStatus.Active);

        builder.HasIndex(model => new
        {
            model.SubRedditId,
            model.UserId
        }).IsUnique();

        //Many to many relationship with SubRedditModerator for SubReddit
        builder.HasOne(model => model.User)
            .WithMany(user => user.SubRedditModerators)
            .HasForeignKey(model => model.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(model => model.SubReddit)
            .WithMany(subreddit => subreddit.Moderators)
            .HasForeignKey(model => model.SubRedditId);
    }
}
