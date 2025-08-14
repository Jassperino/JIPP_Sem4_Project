using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JIPP_Projekt_Sem4.Models.Configurations;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(255);
            
    }
}