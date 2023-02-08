using Lupy.Models;
using Lupy.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lupy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineRepository _vaccineRepository;

        public VaccineController(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VaccineModel>?>> FindAll()
        {
            List<VaccineModel>? vaccines = await _vaccineRepository.FindAll();
            return Ok(vaccines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineModel?>> FindById(int id)
        {
            VaccineModel? vaccine = await _vaccineRepository.FindById(id);
            return Ok(vaccine);
        }

        [HttpPost]
        public async Task<ActionResult<VaccineModel>> Create([FromBody] VaccineModel vaccineModel)
        {
            VaccineModel vaccine = await _vaccineRepository.Create(vaccineModel);
            return Ok(vaccine);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<VaccineModel>> Update([FromBody] VaccineModel vaccineModel, int id)
        {
            VaccineModel vaccine = await _vaccineRepository.Update(vaccineModel, id);
            return Ok(vaccine);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await _vaccineRepository.Delete(id);
            return Ok(result);
        }
    }
}
