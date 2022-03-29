using API_Equipo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Equipo1.Repository
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            //builder.HasIndex(r => new { r.IdCategoria, r.IdSucursal }).HasDatabaseName("UI_CategoriSucursal").IsUnique();

            builder.HasOne(typeof(Categoria)).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(typeof(Sucursal)).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
