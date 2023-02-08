using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Lupy.Repositories
{
    public class AnimalVaccineRepository : IAnimalVaccineRepository
    {
        private readonly LupyDBContext _dbContext;
        public AnimalVaccineRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }

        public async Task<List<AnimalVaccineModel>?> FindAll()
        {
            return await _dbContext.AnimalsVaccines.ToListAsync();
        }

        public async Task<AnimalVaccineModel?> FindById(int id)
        {
            return await _dbContext.AnimalsVaccines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AnimalVaccineModel>?> FindByAnimalId(int animalId)
        {
            return await _dbContext.AnimalsVaccines.Where(x => x.AnimalId == animalId).ToListAsync();
        }

        public async Task<List<AnimalVaccineModel>?> FindByVaccineId(int vaccineId)
        {
            return await _dbContext.AnimalsVaccines.Where(x => x.VaccineId == vaccineId).ToListAsync();
        }

        public async Task<List<AnimalVaccineModel>?> FindByAnimalIdAndVaccineId(int animalId, int vaccineId)
        {
            return await _dbContext.AnimalsVaccines.Where(x => x.VaccineId == vaccineId && x.AnimalId == animalId).ToListAsync();
        }

        public async Task<AnimalVaccineModel?> FindByAnimalIdAndVaccineIdAndDtApplication(int animalId, int vaccineId, DateTime dtApplication)
        {
           return await _dbContext.AnimalsVaccines.FirstOrDefaultAsync(x => x.AnimalId == animalId && x.VaccineId == vaccineId && x.DtApplication == dtApplication);
        }

        public async Task<List<AnimalVaccineModel>?> FindByAnimalIdAndVaccineIdAndDtRevacination(int animalId, int vaccineId, DateTime dtRevacination)
        {
            return await _dbContext.AnimalsVaccines.Where(x => x.AnimalId == animalId && x.VaccineId == vaccineId && x.DtRevaccination == dtRevacination).ToListAsync();
        }

        public async Task<List<AnimalVaccineModel>?> FindByAnimalIdAndVaccineIdAndDtApplicationAndDtRevacination(int animalId, int vaccineId, DateTime? dtApplication, DateTime? dtRevacination)
        {
            return await _dbContext.AnimalsVaccines.Where(x => x.AnimalId == animalId && x.VaccineId == vaccineId && x.DtApplication == dtApplication && x.DtRevaccination == dtRevacination).ToListAsync();
        }

        public async Task<AnimalVaccineModel> Create(AnimalVaccineModel animalVaccine)
        {
            AnimalVaccineModel? animalByIdAndVaccineIdAndDtApplication = await FindByAnimalIdAndVaccineIdAndDtApplication(animalVaccine.AnimalId, animalVaccine.VaccineId, animalVaccine.DtApplication);

            if (animalByIdAndVaccineIdAndDtApplication != null)
            {
                throw new Exception("Vacina já foi cadastrada neste animal!");
            }

            await _dbContext.AnimalsVaccines.AddAsync(animalVaccine);
            await _dbContext.SaveChangesAsync();

            return animalVaccine;
        }
        public async Task<AnimalVaccineModel> Update(AnimalVaccineModel animalVaccine, int id)
        {
            AnimalVaccineModel? animalVaccineById = await FindById(id);

            if (animalVaccineById == null)
            {
                throw new Exception($"Animal Vaccine with ID: {id} not found in database");
            }

            animalVaccineById.DtApplication = animalVaccine.DtApplication;
            animalVaccineById.DtRevaccination = animalVaccine.DtRevaccination;
            animalVaccineById.VaccineId = animalVaccine.VaccineId;
            animalVaccineById.AnimalId = animalVaccine.AnimalId;
            animalVaccineById.ImagePath = animalVaccine.ImagePath;

            _dbContext.AnimalsVaccines.Update(animalVaccineById);
            await _dbContext.SaveChangesAsync();

            return animalVaccineById;
        }

        public async Task<bool> Delete(int id)
        {
            AnimalVaccineModel? animalVaccineById = await FindById(id);

            if(animalVaccineById == null)
            {
                throw new Exception($"Animal Vaccine with ID: {id} not found in database");
            }

            _dbContext.AnimalsVaccines.Remove(animalVaccineById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
