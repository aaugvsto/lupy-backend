using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IVaccineRepository
    {
        Task<List<VaccineModel>> FindAll();
        Task<VaccineModel> FindById(int id);
        Task<List<VaccineModel>> FindByName(string vaccineName); 
        Task<VaccineModel> Create(VaccineModel vaccine);
        Task<VaccineModel> Update(VaccineModel vaccine, int id);
        Task<bool> Delete(int id);
    }
}
