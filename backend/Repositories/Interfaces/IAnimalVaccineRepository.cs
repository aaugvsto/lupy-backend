using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IAnimalVaccineRepository
    {
        Task<List<AnimalVaccineModel>> FindAll();
        Task<AnimalVaccineModel> FindById(int id);
        Task<List<AnimalVaccineModel>?> FindByAnimalId(int id);
        Task<List<AnimalVaccineModel>?> FindByVaccineId(int id);
        Task<List<AnimalVaccineModel>?> FindByAnimalIdAndVaccineId(int animalId, int vaccineId);
        Task<List<AnimalVaccineModel>?> FindByAnimalIdAndVaccineIdAndDtApplicationAndDtRevacination(int animalId, int vaccineId, DateTime? dtApplication, DateTime? dtRevacination);
        Task<AnimalVaccineModel> Create(AnimalVaccineModel animalVaccine);
        Task<AnimalVaccineModel> Update(AnimalVaccineModel animalVaccine, int id);
        Task<bool> Delete(int id);
    }
}
