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

        builder.HasOne(model => model.Moderator)
            .WithMany()
            .HasForeignKey(model => model.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
