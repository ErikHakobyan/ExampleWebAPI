using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseAccessLayer.FluentApiConfig;

internal class UserConfigs : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(t => t.Id)
           .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .HasMaxLength(40)
            .IsRequired();
    }
}

