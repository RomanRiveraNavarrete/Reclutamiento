using API_Equipo1.Models;
using API_Equipo1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Equipo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ContextTacos _context;
        public ProductoController(ContextTacos context)
        {
            _context = context;
        }
        // GET: api/<ProductoController>
        /// <summary>
        /// Obtiene el listado de todos los productos
        /// </summary>
        /// <returns>listado de todos los productos registrados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET api/<ProductoController>/5
        /// <summary>
        /// Obtiene el producto seleccionado por Id
        /// </summary>
        /// <returns>el producto seleccionado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound("El producto no existe");
            }
            return producto;
        }

        /// <summary>
        /// Obtiene el producto seleccionado por IdSucursal
        /// </summary>
        /// <returns>Productos pertenecientes a la misma sucursal</returns>
        [HttpGet("/bySucursal/"+"{idSucursal}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosByIdSucursal(int idSucursal)
        {
            return await _context.Productos.Where(x => x.IdSucursal == idSucursal).ToListAsync();

        }

        // POST api/<ProductoController>
        /// <summary>
        /// Agrega un producto
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost("Producto")]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            CreatedAtAction(nameof(GetProducto), new { id = producto.Id });
            return Ok(producto);
        }

        // PUT api/<ProductoController>/5
        /// <summary>
        /// Actuliza producto por su {Id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="producto"></param>
        /// <returns>Producto seleccionado una vez que se modifica</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> Put(Producto producto, int id)
        {

            if (producto.Id != id)
            { return NotFound("El producto no existe o los id no coinciden."); }
            else
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);
            }

           
        }
        // DELETE api/<ProductoController>/5
        /// <summary>
        /// Elimina el producto seleccionado por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("Producto/{id}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            { return NotFound("El producto no existe o ya ha sido eliminado."); }
            else
            {
                _context.Remove(producto);
                _context.SaveChanges();
                return Ok("Producto removido.");
            }
        }
    }
}
