using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class AnimalBreedMap : IEntityTypeConfiguration<AnimalBreedModel>
    {
        public void Configure(EntityTypeBuilder<AnimalBreedModel> builder)
        {
            // Table name
            builder.ToTable("ANIMAL_BREED");

            // Primary key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.AnimalTypeId).IsRequired().HasColumnName("ID_ANIMAL_TYPE");
            builder.Property(x => x.Name).IsRequired().HasColumnName("NAME");
            builder.Property(x => x.IsActive).IsRequired().HasColumnName("IS_ACTIVE");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");

            // Indexes
            builder.HasIndex(x => x.AnimalTypeId);

            // Relationships
            builder.HasOne(x => x.AnimalType)
                .WithMany().HasForeignKey(fk => fk.AnimalTypeId);
        }
    }
}
