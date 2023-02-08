using Lupy.Models;
using Lupy.Repositories;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lupy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {
        private readonly IAnimalTypeRepository _animalTypeRepository;

        public AnimalTypeController(IAnimalTypeRepository AnimalTypeModel)
        {
            _animalTypeRepository = AnimalTypeModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalTypeModel>?>> FindAll()
        {
            List<AnimalTypeModel>? animals = await _animalTypeRepository.FindAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalTypeModel?>> FindById(int id)
        {
            AnimalTypeModel? animal = await _animalTypeRepository.FindById(id);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalTypeModel>> Create([FromBody] AnimalTypeModel AnimalTypeModel)
        {
            AnimalTypeModel animal = await _animalTypeRepository.Create(AnimalTypeModel);
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<AnimalTypeModel>> Update([FromBody] AnimalTypeModel AnimalTypeModel, int id)
        {
            AnimalTypeModel animal = await _animalTypeRepository.Update(AnimalTypeModel, id);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _animalTypeRepository.Delete(id);
            return Ok(result);
        }
    }
}
