using System.ComponentModel.DataAnnotations;

namespace empresax.permiso.api.domain.DTO
{
    public class PermissionDTO
    {
        public int id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string name {get; set;}

        [Required]
        [MaxLength(50)]
        public string lastName {get;set;}

        [Required]
        public PermissionTypeDTO type {get;set;}

        [MinLength(19)]
        [MaxLength(19)]

        public string date {get; set;}
    }
}