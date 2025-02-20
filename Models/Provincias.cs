using System.ComponentModel.DataAnnotations.Schema;

namespace repasoFinal2daMesa.Models
{
    [Table("provincias")]
    public class Provincias
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

    }
}
