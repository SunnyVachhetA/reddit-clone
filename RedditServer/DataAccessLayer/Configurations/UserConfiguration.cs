using Common.Constants;
using Common.Enums;
using Entities.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;
public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //Generating GUID for User ID
        builder.Property(user => user.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(user => user.Status)
            .HasDefaultValue(UserStatusType.Active);

        builder.Property(user => user.Avatar)
            .HasDefaultValue(SystemConstants.DefaultUserAvatar);

        builder.HasIndex(user => user.Username)
            .IsUnique();

        builder.HasIndex(user => user.Email)
            .IsUnique();
    }
}
