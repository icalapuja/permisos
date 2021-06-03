using System;
using System.Collections.Generic;
using empresax.permiso.api.domain.aggregate;

namespace empresax.permiso.api.domain.repository
{
    public interface IPermissionRepository : IGeneralRepository<PermissionAggregate, Int32>
    {
         
    }
}