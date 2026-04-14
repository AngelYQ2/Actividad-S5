using ActividadS5.Models;
using ActividadS5.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActividadS5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadosController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmpleado(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
            await _empleadoRepository.SaveAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Empleadoid }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Empleadoid)
                return BadRequest();

            _empleadoRepository.Update(empleado);
            await _empleadoRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
                return NotFound();

            _empleadoRepository.Delete(empleado);
            await _empleadoRepository.SaveAsync();

            return NoContent();
        }
    }
}