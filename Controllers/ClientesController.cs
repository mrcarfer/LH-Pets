
using LH_Pets_Projeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets_Projeto.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private static readonly List<Cliente> clientes = new();
        private static int proximoId = 1;

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(clientes);
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            cliente.Id = proximoId++;
            clientes.Add(cliente);

            return StatusCode(201, cliente);
        }
    }
}
