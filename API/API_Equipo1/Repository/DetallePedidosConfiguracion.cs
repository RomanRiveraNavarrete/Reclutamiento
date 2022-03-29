using API_Equipo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Equipo1.Repository
{
    public class DetallePedidosConfiguracion : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.HasIndex(r => new { r.IdPedido, r.IdProducto }).HasDatabaseName("UI_CompraProducto").IsUnique();

            builder.HasOne(typeof(Producto)).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(typeof(Pedido)).WithMany().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
