using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class AnimalVaccineMap : IEntityTypeConfiguration<AnimalVaccineModel>

    {
        public void Configure(EntityTypeBuilder<AnimalVaccineModel> builder)
        {
            // Table name
            builder.ToTable("ANIMAL_VACCINE");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.VaccineId).HasColumnName("ID_VACCINE");
            builder.Property(x => x.AnimalId).HasColumnName("ID_ANIMAL");
            builder.Property(x => x.ImagePath).IsRequired().HasColumnName("IMAGE_PATH");
            builder.Property(x => x.DtApplication).IsRequired().HasColumnName("DT_APPLICATION");
            builder.Property(x => x.DtRevaccination).HasColumnName("DT_REVACCINATION");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");

            // Relationships
            builder.HasOne(x => x.Animal)
                .WithMany().HasForeignKey(fk => fk.AnimalId);
            builder.HasOne(x => x.Vaccine)
                .WithMany().HasForeignKey(fk => fk.VaccineId);

            // Indexes
            builder.HasIndex(x => x.AnimalId);
            builder.HasIndex(x => x.VaccineId);
        }
    }
}
