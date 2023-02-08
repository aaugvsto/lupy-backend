using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lupy.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly LupyDBContext _dbContext;
        public AnimalRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }

        public async Task<List<AnimalModel>?> FindAll()
        {
            return await _dbContext.Animals.ToListAsync();
        }

        public async Task<AnimalModel?> FindById(int id)
        {
            return await _dbContext.Animals.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<AnimalModel>?> FindByName(string animalName)
        {
            return await _dbContext.Animals.Where(x => x.Name == animalName).ToListAsync();
        }

        public async Task<AnimalModel> Create(AnimalModel animal)
        {
            await _dbContext.Animals.AddAsync(animal);
            await _dbContext.SaveChangesAsync();

            return animal;
        }

        public async Task<AnimalModel> Update(AnimalModel animal, int id)
        {
            AnimalModel? animalById = await FindById(id);

            if(animalById == null)
            {
                throw new Exception($"Animal with ID: {id} not found in database");
            }

            animalById.Name = animal.Name;
            animalById.Age = animal.Age;
            animalById.Sex = animal.Sex;
            animalById.DtUpdated = DateTime.Now;

            _dbContext.Animals.Update(animalById);
            await _dbContext.SaveChangesAsync();

            return animalById;
        }

        public async Task<bool> Delete(int id)
        {
            AnimalModel? animalById = await FindById(id);

            if (animalById == null)
            {
                throw new Exception($"User with ID: {id} not found");
            }

            _dbContext.Animals.Remove(animalById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
