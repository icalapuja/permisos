using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.DTO;
using empresax.permiso.api.domain.aggregate;

namespace empresax.permiso.api.application.transform
{
    public interface IPermissionTransform: IGeneralTransform<PermissionDTO, PermissionAggregate>
    {
         
    }
}