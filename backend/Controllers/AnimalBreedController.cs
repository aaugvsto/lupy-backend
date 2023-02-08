using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lupy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalBreedController : ControllerBase
    {
        private readonly IAnimalBreedRepository _animalBreedRepository;

        public AnimalBreedController(IAnimalBreedRepository animalBreedRepository)
        {
            _animalBreedRepository = animalBreedRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalBreedModel>?>> FindAll()
        {
            List<AnimalBreedModel>? animals = await _animalBreedRepository.FindAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalBreedModel?>> FindById(int id)
        {
            AnimalBreedModel? animal = await _animalBreedRepository.FindById(id);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalBreedModel>> Create([FromBody] AnimalBreedModel AnimalBreedModel)
        {
            AnimalBreedModel animal = await _animalBreedRepository.Create(AnimalBreedModel);
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<AnimalBreedModel>> Update([FromBody] AnimalBreedModel AnimalBreedModel, int id)
        {
            AnimalBreedModel animal = await _animalBreedRepository.Update(AnimalBreedModel, id);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _animalBreedRepository.Delete(id);
            return Ok(result);
        }
    }
}
