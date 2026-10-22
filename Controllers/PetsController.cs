
using LH_Pets_Projeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets_Projeto.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        private static readonly List<Pet> pets = new();
        private static int proximoId = 1;

        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return Ok(pets);
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            pet.Id = proximoId++;
            pets.Add(pet);

            return StatusCode(201, pet);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<Pet>> GetPorCliente(int clienteId)
        {
            return Ok(pets.Where(p => p.ClienteId == clienteId).ToList());
        }
    }
}
