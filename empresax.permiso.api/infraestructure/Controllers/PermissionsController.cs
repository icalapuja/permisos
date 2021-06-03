using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.application.service;

namespace empresax.permiso.api.infraestructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionsController : GeneralController<PermissionDTO, Int32>, IPermissionsController
    {
        public PermissionsController(IPermissionService service)
        {
            this.service = service;
        }
    }
}