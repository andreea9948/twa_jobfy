using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.Property(e => e.Id)
            .IsRequired();
        builder.HasKey(x => x.Id);
        builder.Property(e => e.JobName)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.JobType)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.StudyLevel)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.CareerLevel)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.Industry)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(e => e.Requirements)
            .HasMaxLength(3000)
            .IsRequired();
        builder.Property(e => e.Responsibilities)
            .HasMaxLength(3000)
            .IsRequired();
        builder.Property(e => e.Offerings)
            .HasMaxLength(3000)
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .IsRequired();
        builder.Property(e => e.UpdatedAt)
            .IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(e => e.Jobs)
            .HasForeignKey(e => e.UserId)
            .HasPrincipalKey(e => e.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
