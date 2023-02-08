using Lupy.Data;
using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Lupy.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly LupyDBContext _dbContext;
        public VaccineRepository(LupyDBContext lupyDBContext)
        {
            _dbContext = lupyDBContext;
        }

        public async Task<List<VaccineModel>> FindAll()
        {
            return await _dbContext.Vaccines.ToListAsync();
        }

        public async Task<VaccineModel> FindById(int id)
        {
            return await _dbContext.Vaccines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VaccineModel>> FindByName(string vaccineName)
        {
            return await _dbContext.Vaccines.Where(x => x.Name == vaccineName).ToListAsync();
        }

        public async Task<VaccineModel> Create(VaccineModel vaccine)
        {
            var nameExists = await FindByName(vaccine.Name);

            if (nameExists != null)
            {
                throw new Exception("Vaccine name already belongs to another!");
            }

            await _dbContext.AddAsync(vaccine);
            await _dbContext.SaveChangesAsync();

            return vaccine;
        }
        public async Task<VaccineModel> Update(VaccineModel vaccine, int id)
        {
            VaccineModel vaccineById = await FindById(id);

            if (vaccineById == null)
            {
                throw new Exception($"Vaccine with Id: {id} not found in database!");
            }

            vaccineById.Name = vaccine.Name;
            vaccineById.AnimalType = vaccine.AnimalType;
            vaccineById.DtUpdated = DateTime.Now;

            return vaccineById;
        }

        public async Task<bool> Delete(int id)
        {
            VaccineModel vaccineById = await FindById(id);

            if(vaccineById == null)
            {
                throw new Exception($"Vaccine with Id: {id} not found in database!");
            }

            _dbContext.Remove(vaccineById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
