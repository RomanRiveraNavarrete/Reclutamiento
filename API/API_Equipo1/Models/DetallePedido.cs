using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Equipo1.Models
{
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }



    }
}
