using API_Equipo1.Models;
using API_Equipo1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Equipo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ContextTacos _context;

        public CategoriaController(ContextTacos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las categorias
        /// </summary>
        /// <returns>Listado de categorias</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        /// <summary>
        /// Obtiene la categoria seleccionada por Id
        /// </summary>
        /// <returns>Categoria seleccionada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }
        /// <summary>
        /// Agrega una categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {

            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }
        /// <summary>
        /// Elimina categoria seleccionada por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            var song = await _context.Categorias.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            else
            {
                _context.Categorias.Remove(_context.Categorias.Find(id));
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        /// <summary>
        /// Actuliza categoria por su {Id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns>La categoria seleccionada una vez que se modifica</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            if (id == categoria.Id)
            {

                _context.Update(categoria);
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
