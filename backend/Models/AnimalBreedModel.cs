namespace Lupy.Models
{
    public class AnimalBreedModel
    {
        public int Id { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual AnimalTypeModel? AnimalType { get; set; }
    }
}
