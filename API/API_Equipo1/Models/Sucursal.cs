using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Equipo1.Models
{
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public int Numero { get; set; }
        public int CP { get; set; }
        public string Telefono { get; set; }

    }
}
