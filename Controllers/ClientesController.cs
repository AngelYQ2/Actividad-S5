using ActividadS5.Models;
using ActividadS5.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActividadS5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Clienteid }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Clienteid)
                return BadRequest();

            _clienteRepository.Update(cliente);
            await _clienteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                return NotFound();

            _clienteRepository.Delete(cliente);
            await _clienteRepository.SaveAsync();

            return NoContent();
        }
    }
}