using System;
using System.ComponentModel.DataAnnotations;

namespace empresax.permiso.api.domain.DTO
{
    public class PermissionTypeDTO
    {
        [Required]
        public Int32 id {get;set;}


        [Required]
        [MaxLength(50)]
        public string description {get; set;}
    }
}