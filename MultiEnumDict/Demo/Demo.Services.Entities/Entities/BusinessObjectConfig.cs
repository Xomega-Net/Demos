//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Services.Entities
{
    public class BusinessObjectConfig : IEntityTypeConfiguration<BusinessObject>
    {
        public void Configure(EntityTypeBuilder<BusinessObject> c)
        {
            c.ToTable("BusinessObject")
             .HasKey(e => e.Id);

            // configure properties
          
            c.Property(e => e.Id)
             .HasColumnName("Id")
             .HasColumnType("int")
             .IsRequired()
             .ValueGeneratedOnAdd();

            c.Property(e => e.Stub)
             .HasColumnName("Stub")
             .HasColumnType("varchar")
             .HasMaxLength(30);

            c.Property(e => e.Description)
             .HasColumnName("Description")
             .HasColumnType("varchar")
             .HasMaxLength(255);

            c.Property(e => e.Active)
             .HasColumnName("Active")
             .HasColumnType("bit");

        }
    }
}