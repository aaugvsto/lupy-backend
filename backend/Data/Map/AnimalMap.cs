using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class AnimalMap : IEntityTypeConfiguration<AnimalModel>
    {
        public void Configure(EntityTypeBuilder<AnimalModel> builder)
        {
            // Table name
            builder.ToTable("ANIMAL");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("ID_USER");
            builder.Property(x => x.AnimalTypeId).IsRequired().HasColumnName("ID_ANIMAL_TYPE");
            builder.Property(x => x.AnimalBreedId).IsRequired().HasColumnName("ID_ANIMAL_BREED");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("NAME");
            builder.Property(x => x.Sex).IsRequired().HasMaxLength(1).HasColumnName("SEX");
            builder.Property(x => x.Age).IsRequired().HasColumnName("AGE");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");

            // Relationships
            builder.HasOne(x => x.User)
                .WithMany().HasForeignKey(fk => fk.UserId);
            builder.HasOne(x => x.AnimalType)
                .WithMany().HasForeignKey(fk => fk.AnimalTypeId);

            // Indexes
            builder.HasIndex(x => x.UserId);
        }
    }
}
