using Lupy.Enums;
using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class VaccineMap : IEntityTypeConfiguration<VaccineModel>
    {
        public void Configure(EntityTypeBuilder<VaccineModel> builder)
        {
            // Table name
            builder.ToTable("VACCINE");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("NAME");
            builder.Property(x => x.AnimalTypeId).IsRequired().HasColumnName("ID_ANIMAL_TYPE");
            builder.Property(x => x.IsActive).IsRequired().HasColumnName("IS_ACTIVE");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");

            // Relationships
            builder.HasOne(x => x.AnimalType)
                .WithMany().HasForeignKey(fk => fk.AnimalTypeId);
        }
    }
}
