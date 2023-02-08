using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lupy.Repositories
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {
        private readonly LupyDBContext _dbContext;
        public AnimalTypeRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }

        public async Task<List<AnimalTypeModel>> FindAll()
        {
            return await _dbContext.AnimalsTypes.ToListAsync();
        }

        public async Task<AnimalTypeModel> FindById(int id)
        {
            return await _dbContext.AnimalsTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AnimalTypeModel>> FindByName(string animalTypeName)
        {
            return await _dbContext.AnimalsTypes.Where(x => x.Name == animalTypeName).ToListAsync();
        }

        public async Task<AnimalTypeModel> Create(AnimalTypeModel animalType)
        {
            var typeByName = FindByName(animalType.Name);

            if(typeByName != null)
            {
                throw new Exception("Animal type name already belongs to another!");
            }

            await _dbContext.AddAsync(animalType);
            await _dbContext.SaveChangesAsync();

            return animalType;
        }
        public async Task<AnimalTypeModel> Update(AnimalTypeModel animalType, int id)
        {
            var typeById = await FindById(id);

            if(typeById == null)
            {
                throw new Exception($"Animal type with Id: {id} not found in database!");
            }

            typeById.Name = animalType.Name;

            _dbContext.Update(typeById);
            await _dbContext.SaveChangesAsync();

            return typeById;
        }

        public async Task<bool> Delete(int id)
        {
            var typeById = await FindById(id);

            if (typeById == null)
            {
                throw new Exception($"Animal type with Id: {id} not found in database!");
            }

            _dbContext.Remove(typeById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
