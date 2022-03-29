using API_Equipo1.Models;
using API_Equipo1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Equipo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly ContextTacos _context;

        public DetallePedidoController(ContextTacos context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todas el detalle de cada pedido
        /// </summary>
        /// <returns>Listado de pedidos detallados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedidos()
        {
            return await _context.DetallePedidos.ToListAsync();
        }

        /// <summary>
        /// Obtiene el detalle de un pedido seleccionado por Id
        /// </summary>
        /// <returns>Especificacion del pedido consultado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            return detallePedido;
        }

        /// <summary>
        /// Agrega una especificacion a detalle de un pedido
        /// </summary>
        /// <param name="detallePedido"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {

            _context.Add(detallePedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetallePedido), new { id = detallePedido.Id }, detallePedido);
        }

        /// <summary>
        /// Elimina la especificacion de un pediddo seleccionado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDetallePedido(int id)
        {
            var song = await _context.DetallePedidos.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                _context.DetallePedidos.Remove(_context.DetallePedidos.Find(id));
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        /// <summary>
        /// Actuliza la especificacion de un pediddo por su {Id}
        /// </summary>
        /// <returns>Especifacion del pedido ya modificada</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDetallePedido(int id, [FromBody] DetallePedido detallePedido)
        {
            if (id == detallePedido.Id)
            {

                _context.Update(detallePedido);
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
