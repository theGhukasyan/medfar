using MedfarTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedfarTest.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.SearchableSummaryTitle);
        
        builder.Property(e => e.SearchableSummaryDetails);
        
        builder.Property(e => e.SearchableSummaryExtendedDetails);
        
        builder.Property(e => e.SearchableSummarySearch1);
        
        builder.Property(e => e.SearchableSummarySearch2);
        
        builder.Property(e => e.SearchableSummarySearch3);
        
        builder.Property(e => e.SearchableSummarySearch4);
        
        builder.Property(e => e.SearchableSummarySearch5);
        
        builder.Property(e => e.SearchableSummarySearch6);
        
        builder.Property(e => e.SearchableSummarySearch7);
        
        builder.Property(e => e.SearchableSummarySearchSoundex1);
        
        builder.Property(e => e.SearchableSummarySearchSoundex2);
        
        builder.Property(e => e.SearchableSummarySearch8);
        
        builder.Property(e => e.SearchableSummarySearch9);
        
        builder.Property(e => e.SearchableSummarySearch10);
        
        builder.Property(e => e.SearchableSummarySearch11);
        
        builder.Property(e => e.SearchableSummarySearch12);
        
        builder.Property(e => e.SearchableSummarySearch13);
        
        builder.Property(e => e.Considerations);
        
        builder.Property(e => e.ShortName);
        
        builder.Property(e => e.IsPatient).IsRequired();
        
        builder.Property(e => e.LoginId);
        
        builder.Property(e => e.ProfilePictureId);
    }
}