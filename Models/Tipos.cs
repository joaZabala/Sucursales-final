using System.ComponentModel.DataAnnotations.Schema;

namespace repasoFinal2daMesa.Models
{
    [Table("tipos")]
    public class Tipos
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
