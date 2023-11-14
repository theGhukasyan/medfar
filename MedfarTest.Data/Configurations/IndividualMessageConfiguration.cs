using MedfarTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedfarTest.Data.Configurations;

public class IndividualMessageConfiguration : IEntityTypeConfiguration<IndividualMessage>
{
    public void Configure(EntityTypeBuilder<IndividualMessage> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        
        builder.Property(e => e.Id).IsRequired();
        
        builder.Property(e => e.Version).IsRequired();
        
        builder.Property(e => e.CreationDate).IsRequired();
        
        builder.Property(e => e.CreatedBy).IsRequired();
        
        builder.Property(e => e.LastUpdateDate);
        
        builder.Property(e => e.LastUpdatedBy);
        
        builder.Property(e => e.DeletionDate);
        
        builder.Property(e => e.DeletedBy);
        
        builder.Property(e => e.ArchivalDate);

        builder.Property(e => e.ArchivedBy);
        
        builder.Property(e => e.Subject);
        
        builder.Property(e => e.Body);
        
        builder.Property(e => e.SendDate).IsRequired();
        
        builder.Property(e => e.IsTask).IsRequired();
        
        builder.Property(e => e.StartDate);
        
        builder.Property(e => e.DueDate);
        
        builder.Property(e => e.IsDraft).IsRequired();
        
        builder.Property(e => e.IsGroupTask);
        
        builder.Property(e => e.DocumentPatientId);
        
        builder.Property(e => e.FileName);
        
        builder.Property(e => e.TypeTaskLookupId);
        
        builder.Property(e => e.PriorityLookupId);
        
        builder.Property(e => e.FromContactId).IsRequired();
    }
}