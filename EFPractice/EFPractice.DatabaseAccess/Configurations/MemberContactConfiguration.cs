using EFPractice.DatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFPractice.DatabaseAccess.Configurations;

public class MemberContactConfiguration : IEntityTypeConfiguration<MemberContact>
{
    public void Configure(EntityTypeBuilder<MemberContact> builder)
    {
        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.Phone)
            .IsRequired();

        builder.Property(mc => mc.Address)
            .IsRequired();

        builder.Property(mc => mc.City)
            .IsRequired();

        builder
            .HasOne(mc => mc.Member)
            .WithOne(m => m.MemberContact)
            .HasForeignKey<MemberContact>(mc => mc.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}