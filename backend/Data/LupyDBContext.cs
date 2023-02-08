using Lupy.Data.Map;
using Lupy.Models;
using Microsoft.EntityFrameworkCore;

namespace Lupy.Data
{
    public class LupyDBContext : DbContext
    {
        public LupyDBContext(DbContextOptions<LupyDBContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AnimalTypeModel> AnimalsTypes { get; set; }
        public DbSet<AnimalBreedModel> AnimalsBreeds { get; set; }
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<VaccineModel> Vaccines { get; set; }
        public DbSet<AnimalVaccineModel> AnimalsVaccines { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
    
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AnimalTypeMap());
            modelBuilder.ApplyConfiguration(new AnimalBreedMap());
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new VaccineMap());
            modelBuilder.ApplyConfiguration(new AnimalVaccineMap());
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
