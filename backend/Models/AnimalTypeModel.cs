namespace Lupy.Models
{
    public class AnimalTypeModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
    }
}
