using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>?> FindAll();
        Task<AnimalModel?> FindById(int id);
        Task<List<AnimalModel>?> FindByName(string animalName);
        Task<AnimalModel> Create(AnimalModel animal);
        Task<AnimalModel> Update(AnimalModel animal, int id);
        Task<bool> Delete(int id);
    }
}
