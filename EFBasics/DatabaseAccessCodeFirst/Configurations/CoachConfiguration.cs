using DatabaseAccessCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAccessCodeFirst.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<CoachEntity>
    {
        public void Configure(EntityTypeBuilder<CoachEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasMany(c => c.Teams)
                .WithOne(t => t.Coach)
                .HasForeignKey(t => t.CoachId);
        }
    }
}
