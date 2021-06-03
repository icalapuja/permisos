using System;
using Microsoft.AspNetCore.Mvc;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.application.service;

namespace empresax.permiso.api.infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypeController: GeneralController<PermissionTypeDTO, Int32>, IPermissionTypeController
    {
        public PermissionTypeController(IPermissionTypeService service)
        {
            this.service = service;
        }
        
    }
}