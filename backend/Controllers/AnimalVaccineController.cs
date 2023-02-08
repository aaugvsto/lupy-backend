using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lupy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalVaccineController : ControllerBase
    {
        private readonly IAnimalVaccineRepository _animalVaccineRepository;

        public AnimalVaccineController(IAnimalVaccineRepository animalVaccineRepository)
        {
            _animalVaccineRepository = animalVaccineRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalVaccineModel>?>> FindAll()
        {
            List<AnimalVaccineModel>? animals = await _animalVaccineRepository.FindAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalVaccineModel?>> FindById(int id)
        {
            AnimalVaccineModel? animal = await _animalVaccineRepository.FindById(id);
            return Ok(animal);
        }

        [HttpGet("animal/{id}")]
        public async Task<ActionResult<List<AnimalVaccineModel>?>> FindByAnimalId(int id)
        {
            List<AnimalVaccineModel>? animalVaccines = await _animalVaccineRepository.FindByAnimalId(id);
            return Ok(animalVaccines);
        }

        [HttpGet("vaccine/{id}")]
        public async Task<ActionResult<List<AnimalVaccineModel>?>> FindByVaccineId(int id)
        {
            List<AnimalVaccineModel>? animalsVaccines = await _animalVaccineRepository.FindByVaccineId(id);
            return Ok(animalsVaccines);
        }

        [HttpGet("{animalId},{vaccineId},{dtApplication},{dtRevacination}")]
        public async Task<ActionResult<AnimalVaccineModel?>> FindByAnimalIdAndVaccineIdAndDtApplicationAndDtRevacination(int animalId, int vaccineId, string? dtApplication, string? dtRevacination)
        {
            DateTime? parsedDtApplication = null;
            DateTime? parsedDtRevacination = null;

            if (dtApplication != null)
            {
                parsedDtApplication = DateTime.Parse(dtApplication);
            }

            if (dtRevacination != null)
            {
                parsedDtRevacination = DateTime.Parse(dtRevacination);
            }

            var animalVaccine = await _animalVaccineRepository.FindByAnimalIdAndVaccineIdAndDtApplicationAndDtRevacination(animalId, vaccineId, parsedDtApplication, parsedDtRevacination);
            return Ok(animalVaccine);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalVaccineModel>> Create([FromBody] AnimalVaccineModel animalVaccineModel)
        {
            AnimalVaccineModel animal = await _animalVaccineRepository.Create(animalVaccineModel);
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<AnimalVaccineModel>> Update([FromBody] AnimalVaccineModel animalVaccineModel, int id)
        {
            AnimalVaccineModel animal = await _animalVaccineRepository.Update(animalVaccineModel, id);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _animalVaccineRepository.Delete(id);
            return Ok(result);
        }
    }
}
