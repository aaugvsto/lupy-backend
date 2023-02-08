using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class AnimalTypeMap : IEntityTypeConfiguration<AnimalTypeModel>
    {
        public void Configure(EntityTypeBuilder<AnimalTypeModel> builder)
        {
            // Table Name
            builder.ToTable("ANIMAL_TYPE");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnName("NAME");
            builder.Property(x => x.IsActive).IsRequired().HasColumnName("IS_ACTIVE");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");

        }
    }
}
