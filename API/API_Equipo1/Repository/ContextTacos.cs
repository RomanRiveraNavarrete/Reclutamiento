using API_Equipo1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Equipo1.Repository
{
    public class ContextTacos : DbContext
    {
        public ContextTacos(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DetallePedidosConfiguracion()); 
            modelBuilder.ApplyConfiguration(new ProductoConfiguracion());
        }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public  virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }

    }
}
