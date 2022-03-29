using API_Equipo1.Models;
using API_Equipo1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Equipo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ContextTacos _context;

        public SucursalController(ContextTacos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene el listado de todas las sucursales
        /// </summary>
        /// <returns>listado de todas las sucursales registradas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        /// <summary>
        /// Obtiene la sucursal selccionada por Id
        /// </summary>
        /// <returns>sucursal seleccionada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
            var song = await _context.Sucursales.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return song;
        }

        /// <summary>
        /// Obtiene el producto seleccionado por su estado
        /// </summary>
        /// <returns>Productos pertenecientes a mismo estado</returns>
        [HttpGet("/byEstado/" + "{estado}")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetProductosByIdSucursal(string estado)
        {
            return await _context.Sucursales.Where(x => x.Estado == estado).ToListAsync();

        }

        /// <summary>
        /// Agrega una nueva sucursal
        /// </summary>
        /// <param name="sucursal}"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {

            _context.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
        }

        /// <summary>
        /// Elimina la sucursal seleccionada por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSucursal(int id)
        {
            var song = await _context.Sucursales.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                _context.Sucursales.Remove(_context.Sucursales.Find(id));
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        /// <summary>
        /// Actuliza sucursal por su {Id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sucursal"></param>
        /// <returns>Sucursal seleccionada una vez que se modifica</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSucursal(int id, [FromBody] Sucursal sucursal)
        {
            if (id == sucursal.Id)
            {

                _context.Update(sucursal);
                await _context.SaveChangesAsync();
                return Ok();

            }
            else
            {
                return NotFound();
            }
        }
    }
}
