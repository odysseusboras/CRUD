using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Data.Configuration
{
    public class DegreeTypeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.ToTable(Degree.TableName, Degree.SchemaName);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);

            //builder
            // .HasMany<CV>(g => g.CVs)
            // .WithOne(s => s.Degree)
            // .HasForeignKey(s => s.DegreeId);

        }
    }
}
