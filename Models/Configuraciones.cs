using System.ComponentModel.DataAnnotations.Schema;

namespace repasoFinal2daMesa.Models
{
    [Table("configuraciones")]
    public class Configuraciones
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public string Valor { get; set; }
    }
}
