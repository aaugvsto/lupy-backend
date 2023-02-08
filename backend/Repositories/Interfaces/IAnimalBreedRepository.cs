using Lupy.Models;

namespace Lupy.Repositories.Interfaces
{
    public interface IAnimalBreedRepository
    {
        Task<List<AnimalBreedModel>?> FindAll();
        Task<AnimalBreedModel?> FindById(int id);
        Task<List<AnimalBreedModel>?> FindByName(string animalBreedName);
        Task<AnimalBreedModel> Create(AnimalBreedModel animalBreed);
        Task<AnimalBreedModel> Update(AnimalBreedModel animalBreed, int id);
        Task<bool> Delete(int id);
    }
}
