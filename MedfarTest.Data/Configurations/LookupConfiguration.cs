using MedfarTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedfarTest.Data.Configurations;

public class LookupConfiguration : IEntityTypeConfiguration<Lookup>
{
    public void Configure(EntityTypeBuilder<Lookup> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Id).IsRequired();
        
        builder.Property(e => e.LookupTypeName);
        
        builder.Property(e => e.LookupTypeCode);
        
        builder.Property(e => e.LookupCode);
        
        builder.Property(e => e.LookupPosition);
        
        builder.Property(e => e.LookupID).IsRequired();
        
        builder.Property(e => e.En);
        
        builder.Property(e => e.Fr);
        
        builder.Property(e => e.EnValueID);
        
        builder.Property(e => e.FrValueID);
        
        builder.Property(e => e.EnLocalizedValueID);
        
        builder.Property(e => e.FrLocalizedValueID);
        
        builder.Property(e => e.LookupTypeID).IsRequired();
    }
}