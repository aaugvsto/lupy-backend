using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lupy.Repositories
{
    public class AnimalBreedRepository : IAnimalBreedRepository
    {
        private readonly LupyDBContext _dbContext;
        public AnimalBreedRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }
        public async Task<List<AnimalBreedModel>?> FindAll()
        {
            return await _dbContext.AnimalsBreeds.ToListAsync();
        }

        public async Task<AnimalBreedModel?> FindById(int id)
        {
            return await _dbContext.AnimalsBreeds.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AnimalBreedModel>?> FindByName(string animalBreedName)
        {
            return await _dbContext.AnimalsBreeds.Where(x => x.Name == animalBreedName).ToListAsync();
        }
        public async Task<AnimalBreedModel> Create(AnimalBreedModel animalBreed)
        {
            try
            {
                var animalBreedByName = await FindByName(animalBreed.Name);

                if (animalBreedByName != null)
                {
                    throw new Exception("This breed name already belongs another");
                }

                await _dbContext.AnimalsBreeds.AddAsync(animalBreed);
                await _dbContext.SaveChangesAsync();

                return animalBreed;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AnimalBreedModel> Update(AnimalBreedModel animalBreed, int id)
        {
            try
            {
                var animalBreedById = await FindById(id);

                if (animalBreedById == null)
                {
                    throw new Exception($"Breed with ID: {id} not fount in database!");
                }

                var animalBreedByName = await FindByName(animalBreed.Name);

                if (animalBreedByName != null)
                {
                    throw new Exception($"This breed name already belongs another");
                }

                animalBreedById.Name = animalBreed.Name;
                animalBreedById.AnimalType = animalBreed.AnimalType;
                animalBreedById.DtUpdated = DateTime.Now;

                _dbContext.AnimalsBreeds.Update(animalBreedById);
                await _dbContext.SaveChangesAsync();

                return animalBreedById;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var animalBreedById = await FindById(id);

                if (animalBreedById == null)
                {
                    throw new Exception($"Breed with ID: {id} not fount in database!");
                }

                _dbContext.AnimalsBreeds.Remove(animalBreedById);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
