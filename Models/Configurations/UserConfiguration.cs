using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JIPP_Projekt_Sem4.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(255);
        builder.Property(x => x.Password)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(255);
        builder.Property(x => x.Birthday);
        builder.HasMany(x => x.Groups)
            .WithMany(x => x.Users)
            .UsingEntity(j => j.ToTable("UserGroupUser"));
        
    }
}