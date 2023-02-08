using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IAnimalTypeRepository
    {
        Task<List<AnimalTypeModel>> FindAll();
        Task<AnimalTypeModel> FindById(int id);
        Task<List<AnimalTypeModel>> FindByName(string animalTypeName);
        Task<AnimalTypeModel> Create(AnimalTypeModel animalType);
        Task<AnimalTypeModel> Update(AnimalTypeModel animalType, int id);
        Task<bool> Delete(int id);
    }
}
