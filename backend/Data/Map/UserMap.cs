using Lupy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lupy.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            // Table name
            builder.ToTable("USER");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Columns Mapping
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("NAME");
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnName("EMAIL");
            builder.Property(x => x.Cellphone).IsRequired().HasMaxLength(25).HasColumnName("CELLPHONE");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255).HasColumnName("PASSWORD");
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true).HasColumnName("IS_ACTIVE");
            builder.Property(x => x.DtCreated).IsRequired().HasDefaultValue(DateTime.Now).HasColumnName("DT_CREATED");
            builder.Property(x => x.DtUpdated).HasColumnName("DT_UPDATED");
        }
    }
}
