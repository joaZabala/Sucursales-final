using repasoFinal2daMesa.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace repasoFinal2daMesa.DTOS
{
    public class SucursalRequest
    {

        public string Nombre { get; set; }
        public string IdCiudad { get; set; }
        public Guid IdTipo { get; set; }

        public Guid IdProvincia { get; set; }

        public string Telefono { get; set; }
        public string NombreTitular { get; set; }
        public string ApellidoTitular { get; set; }

    }
}
