using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Equipo1.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdSucursal { get; set; }
        public int IdCategoria { get; set; }
        public double Precio { get; set; }
        public string RutaImagen { get; set; }

    }
}
