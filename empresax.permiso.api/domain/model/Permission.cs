using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empresax.permiso.api.domain.model
{

    [Table("permiso", Schema = "empresax")]
    public class Permission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nombre_empleado")]
        public string Name {get; set;}
        
        [Column("apellidos_empleado")]
        public string LastName {get;set;}

        [Column("tipo_permiso")]
        public int PermissionTypeId {get;set;}
        public virtual PermissionType PermissionType {get;set;}
 
        [Column("fecha_permiso")]
        public DateTime Date {get; set;}
    }
}