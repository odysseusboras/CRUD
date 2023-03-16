using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Data.Configuration
{
    public class CVTypeConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.ToTable(CV.TableName, CV.SchemaName);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Identifier).HasColumnName("Identifier").ValueGeneratedOnAdd();
            builder.Property(p => p.Identifier).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(255);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(255);
            builder.Property(x => x.Mobile).HasColumnName("Mobile").HasMaxLength(255);
            builder.Property(x => x.DegreeId).HasColumnName("DegreeId");
            builder.Property(x => x.Blob).HasColumnName("Blob");
            builder.Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();

        }
    }
}
