using System.ComponentModel.DataAnnotations.Schema;

namespace repasoFinal2daMesa.Models
{

    [Table("sucursales")]
    public class Sucursales
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string IdCiudad { get; set; }

        [ForeignKey("IdTipo")] public Tipos Tipos { get; set; }
        public Guid IdTipo { get; set; }

        [ForeignKey("IdProvincia")] public Provincias Provincias { get; set; }
        public Guid IdProvincia { get; set; }

        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitular { get; set; }

        public DateTime FechaAlta {  get; set; }



    }
}
