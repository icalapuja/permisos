using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empresax.permiso.api.domain.model
{
    [Table("tipo_permiso", Schema = "empresax")]
    public class PermissionType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("descripcion")]
        public string Description {get; set;}
    }
}