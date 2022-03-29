using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Equipo1.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TotalProducto { get; set; }
        public double Total { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public DateTime FechaCompra { get; set; }

        public Pedido()
        {
            FechaCompra = DateTime.Now;
        }


    }
}
