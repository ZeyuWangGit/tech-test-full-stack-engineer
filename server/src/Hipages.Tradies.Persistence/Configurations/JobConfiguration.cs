using Hipages.Tradies.Domain.Enums;

namespace Hipages.Tradies.Persistence.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("jobs");

        builder.HasKey(j => j.Id);

        builder.Property(j => j.Status).HasConversion(
            v => v.ToString().ToLower(),
            v => (JobStatus)Enum.Parse(typeof(JobStatus), v,true))
            .IsRequired().HasMaxLength(50);

        builder.HasOne(j => j.Suburb)
            .WithMany()
            .HasForeignKey("SuburbId")
            .IsRequired();

        builder.HasOne(j => j.Category)
            .WithMany()
            .HasForeignKey("CategoryId")
            .IsRequired();

        builder.OwnsOne(j => j.Contact, contact =>
        {
            contact.Property(c => c.Name).IsRequired().HasMaxLength(255);
            contact.Property(c => c.Phone).IsRequired().HasMaxLength(255);
            contact.Property(c => c.Email).IsRequired().HasMaxLength(255);
        });

        builder.Property(j => j.Price)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(j => j.Description).IsRequired();

        builder.Property(j => j.CreatedAt).IsRequired();

        builder.Property(j => j.UpdatedAt).IsRequired();

        

        

        
    }
}