using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lupy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalModel>?>> FindAll()
        {
            List<AnimalModel>? animals = await _animalRepository.FindAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalModel?>> FindById(int id)
        {
            AnimalModel? animal = await _animalRepository.FindById(id);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalModel>> Create([FromBody] AnimalModel animalModel)
        {
            AnimalModel animal = await _animalRepository.Create(animalModel);
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<AnimalModel>> Update([FromBody] AnimalModel animalModel, int id)
        {
            AnimalModel animal = await _animalRepository.Update(animalModel, id);
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _animalRepository.Delete(id);
            return Ok(result);
        }
    }
}
