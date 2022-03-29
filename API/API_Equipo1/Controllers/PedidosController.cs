#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Equipo1.Models;
using API_Equipo1.Repository;

namespace API_Equipo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoesController : ControllerBase
    {
        private readonly ContextTacos _context;

        public PedidoesController(ContextTacos context)
        {
            _context = context;
        }

        // GET: api/Pedidoes
        /// <summary>
        /// Obtiene todos los pedidos
        /// </summary>
        /// <returns>Listado de pediddos</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidoes/5
        /// <summary>
        /// Obtiene por {id} el pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pedido consultado</returns>
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }
        /// <summary>
        /// Actuliza el pedido por su {Id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pedido"></param>
        /// <returns>Pedido seleccinado ya modificado</returns>
        // PUT: api/Pedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Agrega un pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        // POST: api/Pedidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddOrder")]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidoes/5
        /// <summary>
        /// Delete pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
