using Lupy.Enums;
using System.Diagnostics;

namespace Lupy.Models
{
    public class VaccineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }

        public virtual AnimalTypeModel AnimalType { get; set; }
    }
}
