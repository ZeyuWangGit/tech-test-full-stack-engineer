namespace Hipages.Tradies.Persistence.Configurations;

public class SuburbConfiguration : IEntityTypeConfiguration<Suburb>
{
    public void Configure(EntityTypeBuilder<Suburb> builder)
    {
        builder.ToTable("suburbs");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(255);
        builder.Property(s => s.Postcode).IsRequired().HasMaxLength(4);
    }
}