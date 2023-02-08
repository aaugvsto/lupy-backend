using Lupy.Enums;

namespace Lupy.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }
        public int AnimalBreedId { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public DateTime DtCreated { get; set; } 
        public DateTime DtUpdated { get; set; } 

        public virtual UserModel User { get; set; }
        public virtual AnimalTypeModel AnimalType { get; set; }
        public virtual AnimalBreedModel AnimalBreed { get; set; }
    }
}
