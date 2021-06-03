using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;

namespace empresax.permiso.api.infraestructure.Controllers
{
    public interface IPermissionTypeController: IGeneralController<PermissionTypeDTO, Int32>
    {
        
    }
}