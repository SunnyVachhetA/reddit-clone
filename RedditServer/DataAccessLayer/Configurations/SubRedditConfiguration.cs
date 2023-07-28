using Common.Enums;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class SubRedditConfiguration
    : IEntityTypeConfiguration<SubReddit>
{
    public void Configure(EntityTypeBuilder<SubReddit> builder)
    {
        builder.HasIndex(model => model.Slug)
            .IsUnique();

        builder.Property(model => model.Status)
            .HasDefaultValue(SubRedditStatusType.Active);

        builder.Property(model => model.Type)
            .HasDefaultValue(SubRedditType.Public);
    }
}