namespace Lupy.Models
{
    public class AnimalVaccineModel
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int VaccineId { get; set; }
        public string ImagePath { get; set; }
        public DateTime DtApplication { get; set; }
        public DateTime? DtRevaccination { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual AnimalModel Animal { get; set; }
        public virtual VaccineModel Vaccine { get; set; }
    }
}
